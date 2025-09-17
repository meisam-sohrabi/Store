using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Second.ApplicationContract.DTO.Base;
using Second.ApplicationContract.DTO.Product;
using Second.Domain.Entities;
using Second.InfrastructureContract.Interfaces;
using Second.InfrastructureContract.Interfaces.Command.Product;
using Second.InfrastructureContract.Interfaces.Query.Category;
using Second.InfrastructureContract.Interfaces.Query.Product;
using System.Net;

namespace Second.Application.Services.Product
{
    public class ProductAppService
    {
        private readonly IProductQueryRespository _productQueryRespository;
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductAppService(IProductQueryRespository productQueryRespository, IProductCommandRepository productCommandRepository, ICategoryQueryRepository categoryQueryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productQueryRespository = productQueryRespository;
            _productCommandRepository = productCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create
        public async Task<BaseResponseDto<ProductDto>> CreateProduct(ProductDto product)
        {
            var output = new BaseResponseDto<ProductDto>
            {
                Message = "خطا در درج محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var categoryExist = await _categoryQueryRepository.GetQueryable()
                .AnyAsync(c => c.Id == product.CategoryId);
            if (!categoryExist)
            {
                output.Message = "دسته‌بندی موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            var mapped = _mapper.Map<ProductEntity>(product);
            _productCommandRepository.Add(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = $"محصول {product.Name} با موفقیت درج شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Edit
        public async Task<BaseResponseDto<ProductDto>> EditProduct(int id, ProductDto product)
        {
            var output = new BaseResponseDto<ProductDto>
            {
                Message = "خطا در بروزرسانی محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            var categoryExist = await _categoryQueryRepository.GetQueryable()
            .AnyAsync(c => c.Id == product.CategoryId);

            if (!categoryExist)
            {
                output.Message = "دسته‌بندی موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }

            var productexist = await _productQueryRespository.GetQueryAble()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (productexist == null)
            {
                output.Message = "محصول موردنظر یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;

                return output;
            }

            var mapped = _mapper.Map(product, productexist);
            _productCommandRepository.Edit(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = "محصول با موفقیت بروزرسانی شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;

            return output;
        }
        #endregion

        #region Delete
        public async Task<BaseResponseDto<ProductDto>> DeleteProduct(int id)
        {
            var output = new BaseResponseDto<ProductDto>
            {
                Message = "خطا در حذف محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            var productexist = await _productQueryRespository.GetQueryAble()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (productexist == null)
            {
                output.Message = "محصول موردنظر یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }

            _productCommandRepository.Delete(productexist);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = "محصول با موفقیت حذف شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region GetAll
        public async Task<BaseResponseDto<List<ProductDto>>> GetAllProduct()
        {
            var output = new BaseResponseDto<List<ProductDto>>
            {
                Message = "خطا در بازیابی محصولات",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var products = await _productQueryRespository.GetAllQueryAble()
                .Select(c => new ProductDto { Name = c.Name, Description = c.Description, CategoryId = c.CategoryId })
                .ToListAsync();
            if (products.Any())
            {
                output.Message = "محصولات با موفقیت دریافت شد";
                output.Success = true;
                output.Data = products;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Get
        public async Task<BaseResponseDto<ProductDto>> GetProduct(int id)
        {
            var output = new BaseResponseDto<ProductDto>
            {
                Message = "خطا در بازیابی محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var product = await _productQueryRespository.GetQueryAble()
                .Where(c => c.Id == id)
                .Select(c => new ProductDto { Name = c.Name, Description = c.Description, CategoryId = c.CategoryId })
                .FirstOrDefaultAsync();
            if (product != null)
            {
                output.Message = "محصول با موفقیت دریافت شد";
                output.Success = true;
                output.Data = product;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

    }
}
