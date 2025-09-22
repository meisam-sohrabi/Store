using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Transaction;
using ShopService.ApplicationContract.Interfaces.Transactions.Product;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Category;
using ShopService.InfrastructureContract.Interfaces.Command.Product;
using ShopService.InfrastructureContract.Interfaces.Command.ProductBrand;
using ShopService.InfrastructureContract.Interfaces.Command.ProductDetail;
using ShopService.InfrastructureContract.Interfaces.Query.Category;
using ShopService.InfrastructureContract.Interfaces.Query.ProductBrand;
using System.Net;

namespace ShopService.Application.Services.Transactions.Product
{
    public class ProductTransactionAppService : IProductTransactionAppService
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductBrandCommandRepository _productBrandCommandRepository;
        private readonly IProductDetailCommanRepository _productDetailCommanRepository;
        private readonly IProductBrandQueryRepository _productBrandQueryRepository;

        public ProductTransactionAppService(ICategoryQueryRepository categoryQueryRepository
            , ICategoryCommandRepository categoryCommandRepository, IUnitOfWork unitOfWork,
             IMapper mapper, IProductCommandRepository productCommandRepository
            , IProductBrandCommandRepository productBrandCommandRepository
            , IProductDetailCommanRepository productDetailCommanRepository, IProductBrandQueryRepository productBrandQueryRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
            _categoryCommandRepository = categoryCommandRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productCommandRepository = productCommandRepository;
            _productBrandCommandRepository = productBrandCommandRepository;
            _productDetailCommanRepository = productDetailCommanRepository;
            _productBrandQueryRepository = productBrandQueryRepository;
        }

        #region Transaction
        public async Task<BaseResponseDto<ProductTransactionDto>> ProductTransaction(ProductTransactionDto productTransactionDto)
        {
            var output = new BaseResponseDto<ProductTransactionDto>
            {
                Message = "خطا در درج اطلاعات",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var categoryExist = await _categoryQueryRepository.GetQueryable()
                    .FirstOrDefaultAsync(c => c.Id == productTransactionDto.CategoryId);
                if (categoryExist == null)
                {
                    output.Message = "دسته بندی یافت نشد";
                    output.StatusCode = HttpStatusCode.Conflict;
                    return output;
                }
                var brandExist = await _productBrandQueryRepository.GetQueryable()
                    .FirstOrDefaultAsync(b => b.Id == productTransactionDto.ProductBrandId);
                if (brandExist == null)
                {
                    output.Message = "برند یافت نشد";
                    output.StatusCode = HttpStatusCode.Conflict;
                    return output;
                }
                await _unitOfWork.BeginTransactionAsync();

                var product = _mapper.Map<ProductEntity>(productTransactionDto.Product);
                product.CategoryId = categoryExist.Id;
                product.ProductBrandId = brandExist.Id;
                _productCommandRepository.Add(product);
                await _unitOfWork.SaveChangesAsync();

                var detail = _mapper.Map<ProductDetailEntity>(productTransactionDto.ProductDetail);
                detail.ProductId = product.Id;
                _productDetailCommanRepository.Add(detail);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();

                output.Message = "محصولات و جزئیات  با موفقیت ایجاد شد";
                output.Success = true;
                output.StatusCode = HttpStatusCode.Created;

                await _unitOfWork.SaveChangesAsync();
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
