using FluentValidation;
using ShopService.ApplicationContract.DTO.Product;

namespace ShopService.ApplicationContract.Validators.Product
{
    public class ProductArabicToPersianValidator : AbstractValidator<ProductArabicToPersianDto>
    {
        public ProductArabicToPersianValidator()
        {
            RuleFor(c => c.Start)
                .NotNull().WithMessage("Start date is required.")
                .NotEmpty().WithMessage("Start date is required.");
                 
            RuleFor(c=> c.End)
                .NotNull().WithMessage("End date is required.")
                .NotEmpty().WithMessage("End date is required.");
        }
    }
}
