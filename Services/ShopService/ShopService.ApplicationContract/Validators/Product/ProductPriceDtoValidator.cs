using FluentValidation;
using ShopService.ApplicationContract.DTO.ProductPrice;

namespace ShopService.ApplicationContract.Validators.Product
{
    public class ProductPriceDtoValidator : AbstractValidator<ProductPriceRequestDto>
    {
        public ProductPriceDtoValidator()
        {
            RuleFor(c => c.Price)
                .NotNull().WithMessage("Price is required.")
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0);
        }
    }
}
