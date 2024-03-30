using Cinemax.Application.Actors.Commands.Create;
using Cinemax.Application.Actors.Common;
using Cinemax.Contracts.Actors;
using Cinemax.Application.Movies.Commands.Create;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class ActorMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<ActorResult, ActorResponse>()
            .Map(dest => dest.Id, src => src.Actor.Id.Value )
            .Map(dest => dest.Firstname, src => src.Actor.FirstName)
            .Map(dest => dest.Lastname, src => src.Actor.LastName)
            .Map(dest => dest.Movies, src => src.Actor.Movies);
            
        config.NewConfig<CreateActorRequest, CreateActorCommand>()
        .Map(dest => dest.Firstname, src => src.Firstname)
        .Map(dest => dest.Lastname, src => src.Lastname)
        .Map(dest => dest.Movies,src => new List<CreateMovieCommand>());
        
    }
}