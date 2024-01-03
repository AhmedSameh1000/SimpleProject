using MediatR;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contract.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Category.CategoryQueries.Models
{
    public record GetCategoriesModelQery() : IRequest<ResponseModel<List<CategoryToReturnDTo>>>;
}