using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ShopService.Application.Services.SignalR;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Order;
using ShopService.ApplicationContract.DTO.Transaction;
using ShopService.ApplicationContract.Interfaces;
using ShopService.ApplicationContract.Interfaces.Order;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Order;
using ShopService.InfrastructureContract.Interfaces.Command.Product;
using ShopService.InfrastructureContract.Interfaces.Command.ProductInventory;
using ShopService.InfrastructureContract.Interfaces.Query.Order;
using ShopService.InfrastructureContract.Interfaces.Query.Product;
using ShopService.InfrastructureContract.Interfaces.Query.ProductDetail;
using ShopService.InfrastructureContract.Interfaces.Query.ProductPrice;
using System.Net;

namespace ShopService.Application.Services.Order
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IProductQueryRespository _productQueryRespository;
        private readonly IMapper _mapper;
        private readonly IUserAppService _userAppService;
        private readonly IOrderCommandRepository _orderCommandRepository;
        private readonly IOrderQueryRepository _orderQueryRepository;
        private readonly IProductDetailQueryRepository _productDetailQueryRepository;
        private readonly IProductPriceQueryRepository _productPriceQueryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<ServerConnection> _hubContext;
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductInventoryCommandRepository _productInventoryCommandRepository;

        public OrderAppService(IProductQueryRespository productQueryRespository
            ,IMapper mapper, IUserAppService userAppService
            ,IOrderCommandRepository orderCommandRepository, IOrderQueryRepository orderQueryRepository,
            IProductDetailQueryRepository productDetailQueryRepository,
            IProductPriceQueryRepository productPriceQueryRepository,
            IUnitOfWork unitOfWork
            ,IHubContext<ServerConnection> hubContext
            ,IProductCommandRepository productCommandRepository
            ,IProductInventoryCommandRepository productInventoryCommandRepository)
        {
            _productQueryRespository = productQueryRespository;
            _mapper = mapper;
            _userAppService = userAppService;
            _orderCommandRepository = orderCommandRepository;
            _orderQueryRepository = orderQueryRepository;
            _productDetailQueryRepository = productDetailQueryRepository;
            _productPriceQueryRepository = productPriceQueryRepository;
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
            _productCommandRepository = productCommandRepository;
            _productInventoryCommandRepository = productInventoryCommandRepository;
        }

        #region GetUserOrder
        public async Task<BaseResponseDto<List<OrderResponseDto>>> GetAllOrders()
        {
            var output = new BaseResponseDto<List<OrderResponseDto>>
            {
                Message = "خطا در دریافت سفارش",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var orders = await _orderQueryRepository.GetQueryable().Where(c => c.UserId == _userAppService.GetCurrentUser())
                .Select(c => new OrderResponseDto
                {
                    OrderedAt = c.OrderedAt,
                    Quantity = c.Quantity,
                    TotalPrice = c.TotalPrice,
                })
                .ToListAsync();
            if (orders.Any())
            {
                output.Message = "محصولات با موفقیت دریافت شد";
                output.Success = true;
                output.Data = orders;
            }
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion


        #region Transaction

        // dto bayad taghir konad chon tranasaction hastesh
        public async Task<BaseResponseDto<OrderTransactionDto>> OrderTransaction(OrderTransactionDto orderTransactionDto,int productId)
        {
            var output = new BaseResponseDto<OrderTransactionDto>
            {
                Message = "خطا در درج اطلاعات",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            try
            {
                var productExist = await _productQueryRespository.GetQueryable()
                    .Where(c => c.Id == productId)
                    .Join(_productPriceQueryRepository.GetQueryable(), p => p.Id, d => d.ProductId, (p, d) => new { Product = p, ProductPrice = d })
                    .FirstOrDefaultAsync();
                if (productExist == null)
                {
                    output.Message = "محصول یافت نشد";
                    output.Success = false;
                    output.StatusCode = HttpStatusCode.NotFound;
                    return output;
                }
                if (productExist.Product.Quantity == 0)
                {
                    output.Message = "عدم موجودی محصول";
                    output.Success = false;
                    output.StatusCode = HttpStatusCode.Conflict;
                    return output;
                }
                if (productExist.Product.Quantity < orderTransactionDto.Order.Quantity)
                {
                    output.Message = "تعداد درخواست بیشتر از موجودی در انبار می باشد";
                    output.Success = false;
                    output.StatusCode = HttpStatusCode.Conflict;
                    return output;
                }
                await _unitOfWork.BeginTransactionAsync();

                var order = _mapper.Map<OrderEntity>(orderTransactionDto.Order);
                order.TotalPrice = productExist.ProductPrice.Price * orderTransactionDto.Order.Quantity;
                order.UserId = _userAppService.GetCurrentUser();
                order.ProductId = productExist.Product.Id;
                await _orderCommandRepository.Add(order);

                productExist.Product.Quantity -= orderTransactionDto.Order.Quantity;
                _productCommandRepository.Edit(productExist.Product);

                var invetory = new ProductInventoryEntity
                {
                    QuantityChange = -orderTransactionDto.Order.Quantity,
                    ProductId = productExist.Product.Id,
                };
                await _productInventoryCommandRepository.Add(invetory);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                await _hubContext.Clients.All.SendAsync("NewOrder", order.Id, order.UserId);
                output.Message = "سفارش  با موفقیت ایجاد شد";
                output.Success = true;
                output.StatusCode = HttpStatusCode.Created;

            }
            catch (Exception ex)
            {

                await _unitOfWork.RollBackTransactionAsync();

                output.Message = "خطای غیرمنتظره رخ داد" + ex.Message;
                output.Success = false;
                output.StatusCode = HttpStatusCode.InternalServerError;
            }
            return output;
        }
        #endregion

    }
}
