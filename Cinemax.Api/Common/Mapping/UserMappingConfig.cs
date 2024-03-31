using Cinemax.Application.Users.Commands.Create;
using Cinemax.Application.Users.Common;
using Cinemax.Contracts.Users;
using Cinemax.Application.Movies.Commands.Create;
using Mapster;
using Cinemax.Domain.User.ValueObjects;
using Cinemax.Application.Users.Queries.Get;
using Cinemax.Domain.User.Entities;

namespace Cinemax.Api.Common.Mapping;
public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<UserResult, UserResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value )
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.Password, src => src.User.Password)
            .Map(dest => dest.BirthDay, src => src.User.BirthDay)
            .Map(dest => dest.Name, src => src.User.Name)
            .Map(dest => dest.Points, src => src.User.Points)
            .Map(dest => dest.Role, src => src.User.Role)
            .Map(dest => dest.Cards, src => src.User.Cards);
            
        config.NewConfig<CreateUserRequest, CreateUserCommand>()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Points, src => 0)
            .Map(dest => dest.Role, src => "USER")
            .Map(dest => dest.Cards, src => new List<CreateCardCommand>())
            .Map(dest => dest, src => src);

        config.NewConfig<DeleteUserRequest, DeleteUserCommand>()
            .Map(dest => dest.Id, src => UserId.Create(new(src.UserId)));

        config.NewConfig<GetUserRequest, GetUserQuery>()
            .Map(dest => dest.UserId, src => UserId.Create(new(src.UserId)));
        
        config.NewConfig<User, UserResponseCore>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Points, src => src.Points);
    }
}
