using Cinemax.Application.Roles.Commands.Create;
using Cinemax.Application.Roles.Common;
using Cinemax.Contracts.Roles;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class RoleMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<RoleResult, RoleResponse>()
            .Map(dest => dest.Id, src => src.Role.Id.Value )
            .Map(dest => dest.Name, src => src.Role.Name);
            
        config.NewConfig<CreateRoleRequest, CreateRoleCommand>()
        .Map(dest => dest.Name, src => src.Name);
    }
}