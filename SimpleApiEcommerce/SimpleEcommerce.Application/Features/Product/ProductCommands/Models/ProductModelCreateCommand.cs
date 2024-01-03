using MediatR;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contract.DTOs.ProductDTOs;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Product.ProductCommands.Models
{
    public record ProductModelCreateCommand(ProductDTO ProductDTO) : IRequest<ResponseModel<string>>;
}