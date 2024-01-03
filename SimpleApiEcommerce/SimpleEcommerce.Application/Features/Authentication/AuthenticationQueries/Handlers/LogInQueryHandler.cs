using MediatR;
using Microsoft.Extensions.Localization;
using SimpleEcommerce.Application.Features.Authentication.AuthenticationQueries.Models;
using SimpleEcommerce.Application.ResponseHandler;
using SimpleEcommerce.Contracts.DTOs.AuthDTOs;
using SimpleEcommerce.Contracts.ServicesContracts;

namespace SimpleEcommerce.Application.Features.Authentication.AuthenticationQueries.Handlers
{
    internal class LogInQueryHandler : ResponseHandlerModel,
        IRequestHandler<LoginModelQuery, ResponseModel<AuthModel>>
    {
        private readonly IAuthServices _AuthServices;

        public LogInQueryHandler(IAuthServices authServices)
        {
            _AuthServices = authServices;
        }

        public async Task<ResponseModel<AuthModel>> Handle(LoginModelQuery request, CancellationToken cancellationToken)
        {
            var Result = await _AuthServices.LoginAsync(request.LogInDto);

            if (Result.Message is not null)
            {
                return BadRequest<AuthModel>(Result.Message);
            }

            return Success(Result);
        }
    }
}