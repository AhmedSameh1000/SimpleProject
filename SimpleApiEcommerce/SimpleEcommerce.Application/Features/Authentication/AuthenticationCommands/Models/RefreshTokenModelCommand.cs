using MediatR;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contracts.DTOs.AuthDTOs;

namespace SimpleEcommerce.Application.Features.Authentication.AuthenticationCommands.Models
{
    public record RefreshTokenModelCommand(string userId) : IRequest<ResponseModel<AuthModel>>;
}