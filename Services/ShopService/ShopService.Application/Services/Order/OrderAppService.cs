using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ShopService.Application.Services.SignalR;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Order;
using ShopService.ApplicationContract.Interfaces;
using ShopService.ApplicationContract.Interfaces.Order;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Order;
using ShopService.InfrastructureContract.Interfaces.Query.Order;
using ShopService.InfrastructureContract.Interfaces.Query.Product;
using ShopService.InfrastructureContract.Interfaces.Query.ProductDetail;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<ServerConnection> _hubContext;

        public OrderAppService(IProductQueryRespository productQueryRespository
            , IMapper mapper, IUserAppService userAppService
            , IOrderCommandRepository orderCommandRepository, IOrderQueryRepository orderQueryRepository,
            IProductDetailQueryRepository productDetailQueryRepository,IUnitOfWork unitOfWork
            ,IHubContext<ServerConnection> hubContext)
        {
            _productQueryRespository = productQueryRespository;
            _mapper = mapper;
            _userAppService = userAppService;
            _orderCommandRepository = orderCommandRepository;
            _orderQueryRepository = orderQueryRepository;
            _productDetailQueryRepository = productDetailQueryRepository;
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
        }
        public async Task<BaseResponseDto<OrderDto>> CreateOrder(OrderDto orderDto)
        {
            var output = new BaseResponseDto<OrderDto>
            {
                Message = "خطا در ایجاد سفارش",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var productExist = await _productQueryRespository.GetQueryable()
                .Join(_productDetailQueryRepository.GetQueryable(),p=> p.Id ,d=> d.ProductId,(p,d)=> new{ product = p,detail = d})
                .FirstOrDefaultAsync(c=> c.product.Id == orderDto.ProductId);
            if (productExist == null)
            {
                output.Message = "محصول موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            var mapped = _mapper.Map<OrderEntity>(orderDto);
            mapped.OrderedAt = DateTime.Now;
            mapped.TotalPrice = productExist.detail.Price * orderDto.Quantity;
            mapped.UserId = _userAppService.GetCurrentUser();
            await _orderCommandRepository.Add(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = $"سفارش  با موفقیت ایجاد شد";
                output.Success = true;
            }
            await _hubContext.Clients.All.SendAsync("NewOrder", mapped.Id,mapped.UserId);

            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }

        public async Task<BaseResponseDto<List<ShowOrderDto>>> GetAllOrders()
        {
            var output = new BaseResponseDto<List<ShowOrderDto>>
            {
                Message = "خطا در دریافت سفارش",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var orders = await _orderQueryRepository.GetQueryable().Where(c => c.UserId == _userAppService.GetCurrentUser())
                .Select(c => new ShowOrderDto
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
    }
}
