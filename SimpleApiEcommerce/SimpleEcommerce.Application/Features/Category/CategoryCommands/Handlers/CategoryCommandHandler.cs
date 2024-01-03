using FluentValidation;
using MediatR;
using SimpleEcommerce.Application.Features.Category.CategoryCommands.Models;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contract.RepositoryContracts;
using SimpleEcommerce.Contract.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Category.CategoryCommands.Handlers
{
    internal class CategoryCommandHandler : ResponseHandlerModel, IRequestHandler<CategoryModelCommand, ResponseModel<string>>
    {
        private readonly ICategoryService _CategoryService;
        private readonly IValidator<CategoryModelCommand> _CategoryValidator;

        public CategoryCommandHandler(ICategoryService categoryService, IValidator<CategoryModelCommand> CategoryValidator)
        {
            _CategoryService = categoryService;
            _CategoryValidator = CategoryValidator;
        }

        public async Task<ResponseModel<string>> Handle(CategoryModelCommand request, CancellationToken cancellationToken)
        {
            var ValidationResult = await _CategoryValidator.ValidateAsync(request);
            if (!ValidationResult.IsValid)
            {
                return BadRequest<string>(string.Join(",", ValidationResult.Errors.Select(c => c.ErrorMessage).ToList()));
            }

            var Response = await _CategoryService.AddAsync(request.CategoryName);

            if (Response is null)
            {
                return BadRequest<string>("Err,Err");
            }

            return Success<string>("Category Create Succefuly");
        }
    }
}