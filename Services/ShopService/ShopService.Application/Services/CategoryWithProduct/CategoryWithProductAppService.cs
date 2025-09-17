using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Second.ApplicationContract.DTO.Base;
using Second.ApplicationContract.DTO.CategoryWithProduct;
using Second.Domain.Entities;
using Second.InfrastructureContract.Interfaces;
using Second.InfrastructureContract.Interfaces.Command.Category;
using Second.InfrastructureContract.Interfaces.Command.Product;
using Second.InfrastructureContract.Interfaces.Query.Category;
using System.Net;

namespace Second.Application.Services.CategoryWithProduct
{
    public class CategoryWithProductAppService
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductCommandRepository _productCommandRepository;

        public CategoryWithProductAppService(ICategoryQueryRepository categoryQueryRepository, ICategoryCommandRepository categoryCommandRepository, IUnitOfWork unitOfWork,
            IMapper mapper, IProductCommandRepository productCommandRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
            _categoryCommandRepository = categoryCommandRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productCommandRepository = productCommandRepository;
        }
        public async Task<BaseResponseDto<CategoryWithProductDto>> CreateCategoryWithProduct(CategoryWithProductDto categoryWithProductDto)
        {


            var output = new BaseResponseDto<CategoryWithProductDto>
            {
                Message = "خطا در درج دسته بندی و محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            try
            {
                var categoryExist = await _categoryQueryRepository.GetQueryable()
                    .AnyAsync(c => c.Name == categoryWithProductDto.Category.Name);
                if (categoryExist)
                {
                    output.Message = "دسته بندی از قبل ثبت شده است";
                    output.StatusCode = HttpStatusCode.Conflict;
                    return output;
                }
                await _unitOfWork.BeginTransactionAsync();
                var category = _mapper.Map<CategoryEntity>(categoryWithProductDto.Category);
                _categoryCommandRepository.Add(category);
                await _unitOfWork.SaveChangesAsync();

               
                var product = _mapper.Map<ProductEntity>(categoryWithProductDto.Product);
                product.CategoryId = category.Id;
                _productCommandRepository.Add(product);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                output.Message = "محصول و دسته بندی با موفقیت ایجاد شد";
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

    }
}
