using Cinemax.Application.Users.Commands.Create;
using Cinemax.Application.Users.Common;
using Cinemax.Contracts.Users;
using Cinemax.Application.Movies.Commands.Create;
using Mapster;
using Cinemax.Domain.User.ValueObjects;
using Cinemax.Application.Users.Queries.Get;
using Cinemax.Domain.User.Entities;
using Cinemax.Application.Cards.Commands.Create;
using Cinemax.Application.Roles.Commands.Create;
using Cinemax.Application.Users.Queries.Login;

namespace Cinemax.Api.Common.Mapping;
public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value )
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.Password, src => src.User.Password)
            .Map(dest => dest.BirthDay, src => src.User.BirthDay)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.Points, src => src.User.Points)
            .Map(dest => dest.Role, src => new CreateRoleCommand(src.User.Role.Name))
            .Map(dest => dest.Cards, src => src.User.Cards.Select(c => new CreateCardCommand(c.Id)))
            .Map(dest => dest.Token, src => src.Token);
            
        config.NewConfig<UserResult, UserResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value )
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.Password, src => src.User.Password)
            .Map(dest => dest.BirthDay, src => src.User.BirthDay)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.Points, src => src.User.Points)
            .Map(dest => dest.Role, src => new CreateRoleCommand(src.User.Role.Name))
            .Map(dest => dest.Cards, src => src.User.Cards.Select(c => new CreateCardCommand(c.Id)));


        config.NewConfig<RegisterRequest, CreateUserCommand>()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Points, src => 0)
            .Map(dest => dest.Role, src => new CreateRoleCommand("USER"))
            .Map(dest => dest.Cards, src => new List<CreateCardCommand>())
            .Map(dest => dest.BirthDay, src => src.BirthDay);
        
        config.NewConfig<CreateUserRequest, CreateUserCommand>()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Points, src => 0)
            .Map(dest => dest.Role, src => new CreateRoleCommand(src.Role))
            .Map(dest => dest.Cards, src => new List<CreateCardCommand>())
            .Map(dest => dest.BirthDay, src => src.BirthDay);

        config.NewConfig<DeleteUserRequest, DeleteUserCommand>()
            .Map(dest => dest.Id, src => UserId.Create(new(src.UserId)));

        config.NewConfig<GetUserRequest, GetUserQuery>()
            .Map(dest => dest.UserId, src => UserId.Create(new(src.UserId)));
        
        config.NewConfig<User, UserResponseCore>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Points, src => src.Points)
            .Map(dest => dest.BirthDay, src => src.BirthDay);
            
            config.NewConfig<User, UserResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Points, src => src.Points)
            .Map(dest => dest.BirthDay, src => src.BirthDay)
            .Map(dest => dest.Points, src => src.Points)
            .Map(dest => dest.Role, src => src.Role)
            .Map(dest => dest.Cards, src => src.Cards);

        config.NewConfig<LoginRequest, LoginQuery>()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            ;
    }
}
