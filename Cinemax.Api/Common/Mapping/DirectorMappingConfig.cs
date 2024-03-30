using Cinemax.Application.Directors.Commands.Create;
using Cinemax.Application.Directors.Common;
using Cinemax.Contracts.Directors;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class DirectorMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<DirectorResult, DirectorResponse>()
            .Map(dest => dest.Id, src => src.Director.Id.Value )
            .Map(dest => dest.Firstname, src => src.Director.FirstName)
            .Map(dest => dest.Lastname, src => src.Director.LastName);
            
        config.NewConfig<CreateDirectorRequest, CreateDirectorCommand>()
        .Map(dest => dest.Firstname, src => src.Firstname)
        .Map(dest => dest.Lastname, src => src.Lastname);
    }
}