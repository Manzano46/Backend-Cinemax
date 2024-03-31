using Cinemax.Application.Actors.Commands.Create;
using Cinemax.Application.Actors.Common;
using Cinemax.Contracts.Actors;
using Cinemax.Application.Movies.Commands.Create;
using Mapster;
using Cinemax.Domain.Actor.ValueObjects;
using Cinemax.Application.Actors.Queries.Get;
using Cinemax.Domain.Actor.Entities;

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

        config.NewConfig<DeleteActorRequest, DeleteActorCommand>()
            .Map(dest => dest.Id, src => ActorId.Create(new(src.ActorId)));

        config.NewConfig<GetActorRequest, GetActorQuery>()
            .Map(dest => dest.ActorId, src => ActorId.Create(new(src.ActorId)));
        
        config.NewConfig<Actor, ActorResponseCore>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Firstname, src => src.FirstName)
            .Map(dest => dest.Lastname, src => src.LastName);
    }
}