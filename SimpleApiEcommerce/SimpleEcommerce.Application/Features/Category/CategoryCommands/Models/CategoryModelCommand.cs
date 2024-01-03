using MediatR;
using SimpleEcommerce.Application.ResponseHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Category.CategoryCommands.Models
{
    public record CategoryModelCommand(string CategoryName) : IRequest<ResponseModel<string>>;
}