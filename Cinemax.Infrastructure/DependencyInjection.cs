using System.Diagnostics.SymbolStore;
using System.Text;
using Cinemax.Application.Common.Interfaces.Authentication;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Common.Interfaces.Services;
using Cinemax.Infrastructure.Authentication;
using Cinemax.Infrastructure.Persistence;
using Cinemax.Infrastructure.Persistence.Repositories;
using Cinemax.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cinemax.Infrastructure;
public static class DependencyInjection{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configurationManager){
        
        services
                .AddAuth(configurationManager)
                .AddPersistance();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services){
        
        services.AddDbContext<CinemaxDbContext>(options => options.UseSqlServer("Server=KEVIN\\SQLEXPRESS;Database=cinemax;User Id=cinemax;Password=cinemax;TrustServerCertificate=true"));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IActorRepository, ActorRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>(); 

        return services;
    }


    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configurationManager){
        var jwtSettings = new JwtSettings();
        configurationManager.Bind(JwtSettings.SectionName, jwtSettings);
        
        services.AddSingleton(Options.Create(jwtSettings) );
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret)
            )

        });

        return services;
    }
}