using MediatR;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contracts.DTOs.AuthDTOs;

namespace SimpleEcommerce.Application.Features.Authentication.AuthenticationCommands.Models
{
    public record RegisterModelCommand(RegisterDto RegisterDto) : IRequest<ResponseModel<AuthModel>>;
}