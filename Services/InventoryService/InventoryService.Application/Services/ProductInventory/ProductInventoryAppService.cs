using AutoMapper;
using InventoryService.ApplicationContract.DTO.Base;
using InventoryService.ApplicationContract.DTO.ProductInventory;
using InventoryService.ApplicationContract.Interfaces.ProductInventory;
using InventoryService.ApplicationContract.Interfaces.RabbitMq;
using InventoryService.Domain.Entities;
using InventoryService.InfrastructureContract.Interfaces;
using InventoryService.InfrastructureContract.Interfaces.Command.ProductInventory;
using System.Net;

namespace InventoryService.Application.Services.ProductInventory
{
    public class ProductInventoryAppService : IProductInventoryAppService
    {
        private readonly IProductInventoryCommandRepository _productInventoryCommandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRabbitMqAppService _rabbitMqAppService;

        public ProductInventoryAppService(IProductInventoryCommandRepository productInventoryCommandRepository
            , IUnitOfWork unitOfWork,IRabbitMqAppService rabbitMqAppService)
        {
            _productInventoryCommandRepository = productInventoryCommandRepository;
            _unitOfWork = unitOfWork;
            _rabbitMqAppService = rabbitMqAppService;
        }
        public async Task<BaseResponseDto<ProductInventoryResponseDto>> CreateProductInventory(ProductInventoryRequestDto productInventoryRequestDto)
        {
            var output = new BaseResponseDto<ProductInventoryResponseDto>
            {
                Message = "خطا در درج اطلاعات",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var inventory = new ProductInventoryEntity
            {
                   QuantityChange = productInventoryRequestDto.QuantityChange,
                   ProductId = productInventoryRequestDto.ProductId
            };
            await _productInventoryCommandRepository.AddAsync(inventory);
            await _unitOfWork.SaveChangesAsync();
            var response = new ProductInventoryResponseDto
            {
                ChangeDate = DateTime.Now,
                QuantityChange = productInventoryRequestDto.QuantityChange
            };
            output.Message = "انبار  با موفقیت ثبت شد";
            output.Success = true;
            output.StatusCode = HttpStatusCode.Created;
            output.Data = response;
            await _rabbitMqAppService.PublishMessage(output.Data);
            return output;
        }
    }
}
