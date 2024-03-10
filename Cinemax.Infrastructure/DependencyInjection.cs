using Cinemax.Application.Common.Interfaces.Authentication;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Common.Interfaces.Services;
using Cinemax.Infrastructure.Authentication;
using Cinemax.Infrastructure.Persistence;
using Cinemax.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure;
public static class DependencyInjection{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configurationManager){
        services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}