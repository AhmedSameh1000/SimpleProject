using FluentValidation;
using MediatR;
using SimpleEcommerce.Application.Features.Authentication.AuthenticationCommands.Models;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contracts.DTOs.AuthDTOs;
using SimpleEcommerce.Contracts.ServicesContracts;

namespace SimpleEcommerce.Application.Features.Authentication.AuthenticationCommands.Handlers
{
    public class RegisterCommandHandler : ResponseHandlerModel,
        IRequestHandler<RegisterModelCommand, ResponseModel<AuthModel>>,
        IRequestHandler<RefreshTokenModelCommand, ResponseModel<AuthModel>>
    {
        private readonly IAuthServices _authServices;
        private readonly IValidator<RegisterDto> _RegisterDtoValidtor;

        public RegisterCommandHandler(
            IAuthServices authServices,
            IValidator<RegisterDto> RegisterDtoValidtor)
        {
            _authServices = authServices;
            _RegisterDtoValidtor = RegisterDtoValidtor;
        }

        public async Task<ResponseModel<AuthModel>> Handle(RegisterModelCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _RegisterDtoValidtor.Validate(request.RegisterDto);
            if (!validationResult.IsValid)
            {
                return BadRequest<AuthModel>(string.Join(",", validationResult.Errors.Select(c => c.ErrorMessage).ToList()));
            }
            var Response = await _authServices.RegisterAsync(request.RegisterDto);

            if (Response.Message is not null)
            {
                return BadRequest<AuthModel>(Response.Message);
            }
            return Success(Response);
        }

        public async Task<ResponseModel<AuthModel>> Handle(RefreshTokenModelCommand request, CancellationToken cancellationToken)
        {
            var Result = await _authServices.RefreshTokenAsync(request.userId);
            if (!Result.IsAuthenticated)
            {
                return BadRequest<AuthModel>();
            }
            return Success(Result);
        }
    }
}