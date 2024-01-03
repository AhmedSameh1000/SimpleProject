using MediatR;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contract.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Product.ProductQueries.Models
{
    public record GetProductsModelQuery() : IRequest<ResponseModel<List<ProductToReturnDto>>>;
}