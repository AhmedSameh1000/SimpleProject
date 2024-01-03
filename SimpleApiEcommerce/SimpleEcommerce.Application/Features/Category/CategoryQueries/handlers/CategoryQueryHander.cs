using MediatR;
using SimpleEcommerce.Application.Features.Category.CategoryQueries.Models;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contract.DTOs.CategoryDTOs;
using SimpleEcommerce.Contract.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Category.CategoryQueries.handlers
{
    internal class CategoryQueryHander : ResponseHandlerModel, IRequestHandler<GetCategoriesModelQery, ResponseModel<List<CategoryToReturnDTo>>>
    {
        private readonly ICategoryService _CategoryService;

        public CategoryQueryHander(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        public async Task<ResponseModel<List<CategoryToReturnDTo>>> Handle(GetCategoriesModelQery request, CancellationToken cancellationToken)
        {
            var Categories = await _CategoryService.GetCategories();

            return Success(Categories);
        }
    }
}