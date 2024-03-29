﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleEcommerce.Application.Features.Authentication.AuthenticationCommands.Models;
using SimpleEcommerce.Application.Features.Product.ProductCommands.Models;
using SimpleEcommerce.Application.Features.Product.ProductQueries.Models;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductDTO productDTO)
        {
            var Response = await _Mediator.Send(new ProductModelCreateCommand(productDTO));

            return NewResult(Response);
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var Response = await _Mediator.Send(new GetProductsModelQuery());

            return NewResult(Response);
        }
    }
}