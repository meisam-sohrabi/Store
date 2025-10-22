﻿using FluentValidation;
using ShopService.ApplicationContract.DTO.ProductDetail;

namespace ShopService.ApplicationContract.Validators.Product
{
    public class ProductDetailDtoValidator : AbstractValidator<ProductDetailRequestDto>
    {
        public ProductDetailDtoValidator()
        {
            RuleFor(c => c.Size)
                .NotNull().WithMessage("Size should be 30 length long.")
                .NotEmpty().WithMessage("Size should be 30 length long.")
                .MaximumLength(30).WithMessage("Size should be 30 length long.");

            RuleFor(c => c.Description)
                .NotNull().WithMessage("Size should be 30 length long.")
                .NotEmpty().WithMessage("Size should be 30 length long.")
                .MinimumLength(350).WithMessage("Description should be 350 length long.");
        }
    }
}
