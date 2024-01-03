using MediatR;
using SimpleEcommerce.Application.Features.Product.ProductQueries.Models;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contract.DTOs.ProductDTOs;
using SimpleEcommerce.Contract.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Product.ProductQueries.Handlers
{
    internal class ProductQueryHandler : ResponseHandlerModel, IRequestHandler<GetProductsModelQuery, ResponseModel<List<ProductToReturnDto>>>
    {
        private readonly IProductService _ProductService;

        public ProductQueryHandler(IProductService productService)
        {
            _ProductService = productService;
        }

        public async Task<ResponseModel<List<ProductToReturnDto>>> Handle(GetProductsModelQuery request, CancellationToken cancellationToken)
        {
            var Products = await _ProductService.GetProducts();

            return Success(Products);
        }
    }
}