using Microsoft.Extensions.DependencyInjection;

namespace SimpleEcommerce.Domain
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection InfrastructureRegistration(this IServiceCollection services)
        {
            return services;
        }
    }
}