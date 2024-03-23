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
            .Map(dest => dest.Id , src => src.User.Id)
            .Map(dest => dest.FirstName , src => src.User.FirstName)
            .Map(dest => dest.LastName , src => src.User.LastName)
            .Map(dest => dest.Email , src => src.User.Email)
            .Map(dest => dest.Birth , src => src.User.Birth)
            .Map(dest => dest.Points , src => src.User.Points);

        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<RegisterRequest, RegisterCommand>();
    }
}