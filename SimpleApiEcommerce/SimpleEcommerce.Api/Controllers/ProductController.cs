using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleEcommerce.Application.Features.Authentication.AuthenticationCommands.Models;
using SimpleEcommerce.Application.Features.Product.ProductCommands.Models;
using SimpleEcommerce.Contract.DTOs.ProductDTOs;
using SimpleEcommerce.Contracts.DTOs.AuthDTOs;

namespace SimpleEcommerce.Api.Controllers
{
    [ApiController]
    public class ProductController : AppBaseController
    {
        private readonly IMediator _Mediator;

        public ProductController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductDTO productDTO)
        {
            var Response = await _Mediator.Send(new ProductModelCreateCommand(productDTO));

            return NewResult(Response);
        }
    }
}