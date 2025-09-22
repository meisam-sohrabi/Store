using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.ProductDetail;
using ShopService.ApplicationContract.DTO.Search;
using ShopService.ApplicationContract.Interfaces.Product;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Product;
using ShopService.InfrastructureContract.Interfaces.Query.Category;
using ShopService.InfrastructureContract.Interfaces.Query.Product;
using ShopService.InfrastructureContract.Interfaces.Query.ProductBrand;
using ShopService.InfrastructureContract.Interfaces.Query.ProductDetail;
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
        private readonly IProductBrandQueryRepository _productBrandQueryRepository;
        private readonly IProductDetailQueryRepository _productDetailQueryRepository;

        public ProductAppService(IProductQueryRespository productQueryRespository,
            IProductCommandRepository productCommandRepository,
            ICategoryQueryRepository categoryQueryRepository,
            IUnitOfWork unitOfWork, IMapper mapper, IProductBrandQueryRepository productBrandQueryRepository
            ,IProductDetailQueryRepository productDetailQueryRepository)
        {
            _productQueryRespository = productQueryRespository;
            _productCommandRepository = productCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productBrandQueryRepository = productBrandQueryRepository;
            _productDetailQueryRepository = productDetailQueryRepository;
        }

        #region Create
        public async Task<BaseResponseDto<ProductResponseDto>> CreateProduct(ProductRequestDto productDto)
        {
            var output = new BaseResponseDto<ProductResponseDto>
            {
                Message = "خطا در ایجاد محصول",
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
            var brandExist = await _productBrandQueryRepository.GetQueryable()
                .AnyAsync(c => c.Id == productDto.BrandId);
            if (!brandExist)
            {
                output.Message = "برند موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            var mapped = _mapper.Map<ProductEntity>(productDto);
            _productCommandRepository.Add(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = $"محصول {productDto.Name} با موفقیت ایجاد شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Edit
        public async Task<BaseResponseDto<ProductResponseDto>> EditProduct(int id, ProductRequestDto productDto)
        {
            var output = new BaseResponseDto<ProductResponseDto>
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
            var brandExist = await _productBrandQueryRepository.GetQueryable()
            .AnyAsync(c => c.Id == productDto.BrandId);
            if (!brandExist)
            {
                output.Message = "برند موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            var productExist = await _productQueryRespository.GetQueryable()
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
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;

            return output;
        }
        #endregion

        #region Delete
        public async Task<BaseResponseDto<ProductResponseDto>> DeleteProduct(int id)
        {
            var output = new BaseResponseDto<ProductResponseDto>
            {
                Message = "خطا در حذف محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            var productExist = await _productQueryRespository.GetQueryable()
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
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region GetAll
        public async Task<BaseResponseDto<List<ProductResponseDto>>> GetAllProduct()
        {
            var output = new BaseResponseDto<List<ProductResponseDto>>
            {
                Message = "خطا در بازیابی محصولات",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var products = await _productQueryRespository.GetQueryable()
                .Select(c => new ProductResponseDto { Name = c.Name, Description = c.Description })
                .ToListAsync();
            if (products.Any())
            {
                output.Message = "محصولات با موفقیت دریافت شد";
                output.Success = true;
                output.Data = products;
            }
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Get
        public async Task<BaseResponseDto<ProductResponseDto>> GetProduct(int id)
        {
            var output = new BaseResponseDto<ProductResponseDto>
            {
                Message = "خطا در بازیابی محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var product = await _productQueryRespository.GetQueryable()
                .Where(c => c.Id == id)
                .Select(c => new ProductResponseDto { Name = c.Name, Description = c.Description })
                .FirstOrDefaultAsync();
            if (product != null)
            {
                output.Message = "محصول با موفقیت دریافت شد";
                output.Success = true;
                output.Data = product;
            }
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Search
        public async Task<BaseResponseDto<List<SearchResponseDto>>> AdvanceSearchProduct(SearchRequstDto searchRequstDto)
        {
            var output = new BaseResponseDto<List<SearchResponseDto>>
            {
                Message = "خطا در دریافت محصول مورد نظر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var searchProduct = await _productQueryRespository.GetQueryable()
                .Where(c => c.Name.Contains(searchRequstDto.Search) || c.Description.Contains(searchRequstDto.Search))
                .Join(_categoryQueryRepository.GetQueryable().Where(c => c.IsActive == true),
                p => p.CategoryId, c => c.Id, (p, c) => new { product = p, category = c })
                .Join(_productBrandQueryRepository.GetQueryable(),
                pc => pc.product.ProductBrandId, b => b.Id, (pc, b) => new { pc.product, pc.category, brand = b })
                .Select(s => new SearchResponseDto
                {
                    produtName = s.product.Name,
                    productBrand = s.brand.Name,
                    categoryName = s.category.Name,
                    productDetail = s.product.ProductDetails
                                    .Select(c => new ProductDetailResponseDto { Description = c.Description, Size = c.Size, Price = c.Price }).ToList(),
                }).ToListAsync();
            if (searchProduct != null)
            {
                output.Message = "محصول مورد نظر با موفقیت دریافت شد";
                output.Success = true;
                output.Data = searchProduct;
            }
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

    }
}





#region Different ways of search query
/*var searchProduct = await _productQueryRespository.GetQueryable()
                .Where(c => c.Name.Contains(searchRequstDto.Search) || c.Description.Contains(searchRequstDto.Search))
                .Include(c => c.Category)
                .Include(c => c.ProductBrand)
                .Include(c => c.ProductDetails)
                .Select(c => new SearchResponseDto
                {
                    categoryName = c.Category.Name,
                    productBrand = c.ProductBrand.Name,
                    produtName = c.Name,
                    productDetail = c.ProductDetails.Select(c => new ProductDetailResponseDto { Description = c.Description, Size = c.Size, Price = c.Price }).ToList()
                }).ToListAsync();*/




/*from prodcut in _productQueryRespository.GetQueryable()
                                join category in _categoryQueryRepository.GetQueryable()
                                on prodcut.CategoryId equals category.Id
                                where category.IsActive == true
                                join brand in _productBrandQueryRepository.GetQueryable()
                                on prodcut.ProductBrandId equals brand.Id
                                join detail in _productDetailQueryRepository.GetQueryable()
                                on prodcut.Id equals detail.ProductId
                                select new SearchResponseDto
                                {
                                   produtName = prodcut.Name,
                                   productBrand = brand.Name,
                                   categoryName = category.Name,
                                   productDetail = detail.Price
                                };*/

/* var searchProduct = await _productQueryRespository.GetQueryable()
                .Where(c => c.Name.Contains(searchRequstDto.Search) || c.Description.Contains(searchRequstDto.Search))
                .Join(_categoryQueryRepository.GetQueryable().Where(c => c.IsActive == true),
                p => p.CategoryId, c => c.Id, (p, c) => new { product = p, category = c })
                .Join(_productBrandQueryRepository.GetQueryable(),
                pc => pc.product.ProductBrandId, b => b.Id, (pc, b) => new { pc.product, pc.category, brand = b })
                .Select(s => new SearchResponseDto
                {
                    produtName = s.product.Name,
                    productBrand = s.brand.Name,
                    categoryName = s.category.Name,
                    productDetail = s.product.ProductDetails
                    .Select(c => new ProductDetailResponseDto { Description = c.Description, Size = c.Size, Price = c.Price }).ToList(),
                }).ToListAsync();*/
#endregion
//Select(s => new SearchResponseDto
//{
//    produtName = s.product.Name,
//    productBrand = s.brand.Name,
//    categoryName = s.category.Name,
//    productDetail = s.product.ProductDetails
//                    .Select(c => new ProductDetailResponseDto { Description = c.Description, Size = c.Size, Price = c.Price }).ToList(),
//}

/*var searchProduct = await _productQueryRespository.GetQueryable()
                .Where(c => c.Name.Contains(searchRequstDto.Search) || c.Description.Contains(searchRequstDto.Search))
                .Join(_categoryQueryRepository.GetQueryable().Where(c => c.IsActive == true),
                p => p.CategoryId, c => c.Id, (p, c) => new { product = p, category = c })
                .Join(_productBrandQueryRepository.GetQueryable(),
                pc => pc.product.ProductBrandId, b => b.Id, (pc, b) => new { pc.product, pc.category, brand = b })
                .SelectMany(c=> c.product.ProductDetails.DefaultIfEmpty(),(pcb,d)=> new SearchResponseDto
                {
                    produtName = pcb.product.Name,
                    productBrand = pcb.brand.Name,
                    categoryName = pcb.category.Name,
                    productDetail = d.Price
                }).ToListAsync();*/