using FluentValidation;
using ShopService.ApplicationContract.DTO.Transaction;

namespace ShopService.ApplicationContract.Validators.Product
{
    public class ProductTransactionDtoValidator : AbstractValidator<ProductTransactionDto>
    {
        public ProductTransactionDtoValidator()
        {
            RuleFor(c => c.Product)
                .NotNull().WithMessage("Product is required.")
                .SetValidator(new ProductDtoValidator());

            RuleFor(c => c.ProductDetail)
                .NotNull().WithMessage("ProductDetail is required.")
                .SetValidator(new ProductDetailDtoValidator());

            RuleFor(c=> c.ProductPrice)
                .NotNull().WithMessage("ProductPrice is required.")
                .SetValidator(new ProductPriceDtoValidator());
        }
    }
}
