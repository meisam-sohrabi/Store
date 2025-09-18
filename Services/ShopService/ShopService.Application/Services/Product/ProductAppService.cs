using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.Search;
using ShopService.ApplicationContract.Interfaces.Product;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Product;
using ShopService.InfrastructureContract.Interfaces.Query.Category;
using ShopService.InfrastructureContract.Interfaces.Query.Product;
using System.Net;

namespace ShopService.Application.Services.Product
{
    public class ProductAppService : IProductAppService
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
        public async Task<BaseResponseDto<ProductDto>> CreateProduct(ProductDto productDto)
        {
            var output = new BaseResponseDto<ProductDto>
            {
                Message = "خطا در درج محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var categoryExist = await _categoryQueryRepository.GetQueryable()
                .AnyAsync(c => c.Id == productDto.CategoryId);
            if (!categoryExist)
            {
                output.Message = "دسته‌بندی موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            var mapped = _mapper.Map<ProductEntity>(productDto);
            _productCommandRepository.Add(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = $"محصول {productDto.Name} با موفقیت درج شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Edit
        public async Task<BaseResponseDto<ProductDto>> EditProduct(int id, ProductDto productDto)
        {
            var output = new BaseResponseDto<ProductDto>
            {
                Message = "خطا در بروزرسانی محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            var categoryExist = await _categoryQueryRepository.GetQueryable()
            .AnyAsync(c => c.Id == productDto.CategoryId);

            if (!categoryExist)
            {
                output.Message = "دسته‌بندی موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }

            var productExist = await _productQueryRespository.GetQueryAble()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (productExist == null)
            {
                output.Message = "محصول موردنظر یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;

                return output;
            }

            var mapped = _mapper.Map(productDto, productExist);
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

            var productExist = await _productQueryRespository.GetQueryAble()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (productExist == null)
            {
                output.Message = "محصول موردنظر یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }

            _productCommandRepository.Delete(productExist);
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
            var products = await _productQueryRespository.GetQueryAble()
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

        #region Search
        // To Do (advance search using join with string search)
        public async Task<BaseResponseDto<SearchResponseDto>> AdvanceSearchProduct(SearchRequstDto searchRequstDto)
        {
            var category = await _categoryQueryRepository.GetQueryable().
            var searchProduct = await _productQueryRespository.GetQueryAble()
                .Where(c=> c.Name.Contains(searchRequstDto.Search) || c.Description.Contains(searchRequstDto.Search)).Join()
        }
        #endregion

    }
}
