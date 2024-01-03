using FluentValidation;
using SimpleEcommerce.Contract.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Product.ProductCommands.Validation
{
    public class ProductModelCreateValidator : AbstractValidator<ProductDTO>
    {
        public ProductModelCreateValidator()
        {
            RuleFor(c => c.Price).NotEmpty().WithMessage("{PropertyName} is Required");
            RuleFor(c => c.MinimumQuantity).NotEmpty().WithMessage("{PropertyName} is Required");
            RuleFor(c => c.Name).NotEmpty().WithMessage("{PropertyName} is Required");

            RuleFor(c => c.CategoryId).NotEmpty().WithMessage("{PropertyName} is Required");
            RuleFor(c => c.DiscountRate).NotEmpty().WithMessage("{PropertyName} is Required");
            RuleFor(c => c.file).NotEmpty().WithMessage("{PropertyName} is Required");

            RuleFor(c => c.Price).NotNull().WithMessage("{PropertyName} is Required");
            RuleFor(c => c.MinimumQuantity).NotNull().WithMessage("{PropertyName} is Required");
            RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} is Required");

            RuleFor(c => c.CategoryId).NotNull().WithMessage("{PropertyName} is Required");
            RuleFor(c => c.DiscountRate).NotNull().WithMessage("{PropertyName} is Required");
            RuleFor(c => c.file).NotNull().WithMessage("{PropertyName} is Required");
        }
    }
}