using FluentValidation;
using MediatR;
using SimpleEcommerce.Application.Features.Product.ProductCommands.Models;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contract.DTOs.ProductDTOs;
using SimpleEcommerce.Contract.ServicesContracts;

namespace SimpleEcommerce.Application.Features.Product.ProductCommands.Handlers
{
    public class ProductCommandhandler : ResponseHandlerModel, IRequestHandler<ProductModelCreateCommand, ResponseModel<string>>
    {
        private readonly IProductService _ProductService;
        private readonly IValidator<ProductDTO> _ProductCreateValidator;

        public ProductCommandhandler(IProductService productService, IValidator<ProductDTO> ProductCreateValidator)
        {
            _ProductService = productService;
            _ProductCreateValidator = ProductCreateValidator;
        }

        public async Task<ResponseModel<string>> Handle(ProductModelCreateCommand request, CancellationToken cancellationToken)
        {
            var ValidationResponse = await _ProductCreateValidator.ValidateAsync(request.ProductDTO);

            if (!ValidationResponse.IsValid)
            {
                return BadRequest<string>(string.Join(",", ValidationResponse.Errors.Select(c => c.ErrorMessage)));
            }

            await _ProductService.AddAsync(request.ProductDTO);

            return Created("Product Created Succesfuly");
        }
    }
}