using Cinemax.Application.Authentication.Commands.Register;
using Cinemax.Application.Authentication.Common;
using Cinemax.Application.Authentication.Queries.Login;
using Cinemax.Contracts.Authentication;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);

        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<RegisterRequest, RegisterCommand>();
    }
}