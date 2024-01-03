using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleEcommerce.Application.Features.Authentication.AuthenticationQueries.Models;
using SimpleEcommerce.Application.Features.Category.CategoryCommands.Models;
using SimpleEcommerce.Application.Features.Category.CategoryQueries.Models;
using SimpleEcommerce.Contracts.DTOs.AuthDTOs;

namespace SimpleEcommerce.Api.Controllers
{
    [ApiController]
    public class CategoryController : AppBaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory(string categoryName)
        {
            var Response = await _mediator.Send(new CategoryModelCommand(categoryName));
            return NewResult(Response);
        }

        [HttpGet("GetCategories")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCategories()
        {
            var Response = await _mediator.Send(new GetCategoriesModelQery());
            return NewResult(Response);
        }
    }
}