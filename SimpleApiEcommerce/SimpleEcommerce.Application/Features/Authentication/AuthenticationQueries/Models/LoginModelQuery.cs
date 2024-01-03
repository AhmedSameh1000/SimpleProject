using MediatR;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contracts.DTOs.AuthDTOs;

namespace SimpleEcommerce.Application.Features.Authentication.AuthenticationQueries.Models
{
    public record LoginModelQuery(LogInDTo LogInDto) : IRequest<ResponseModel<AuthModel>>;
}