using FluentValidation;
using SimpleEcommerce.Application.Features.Category.CategoryCommands.Models;

namespace SimpleEcommerce.Application.Features.Category.CategoryCommands.Validators
{
    public class CategoryCommandValidator : AbstractValidator<CategoryModelCommand>
    {
        public CategoryCommandValidator()
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("{PropertyName}  must Not be Empty")
                .NotNull().WithMessage("{PropertyName} must Not be Null");
        }
    }
}