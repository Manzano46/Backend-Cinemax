using Cinemax.Application.Projections.Commands.Create;
using Cinemax.Application.Projections.Commands.Delete;
using Cinemax.Application.Projections.Queries.Get;
using Cinemax.Application.Projections.Common;
using Cinemax.Contracts.Projections;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Mapster;
using Cinemax.Domain.ProjectionAggregate;

namespace Cinemax.Api.Common.Mapping;
public class ProjectionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
   
        config.NewConfig<ProjectionResult, ProjectionResponse>()
            .Map(dest => dest.Id, src => src.Projection.Id.Value)
            .Map(dest => dest.Date, src => src.Projection.Date)
            .Map(dest => dest.Price, src => src.Projection.Price)
            .Map(dest => dest.Room, src => src.Projection.Room)
            .Map(dest => dest.Movie, src => src.Projection.Movie);

        config.NewConfig<CreateProjectionRequest, CreateProjectionCommand>()
        .Map(dest => dest.MovieId, src => MovieId.Create(new(src.Movie)))
        .Map(dest => dest.RoomId, src => RoomId.Create(new(src.Room)))
        .Map(dest => dest.Date , src => src.Date)
        ;

        config.NewConfig<DeleteProjectionRequest, DeleteProjectionCommand>()
            .Map(dest => dest.Id, src => ProjectionId.Create(new(src.Id)));

        config.NewConfig<GetProjectionRequest, GetProjectionQuery>()
            .Map(dest => dest.projectionId, src => ProjectionId.Create(new(src.Id)));

        config.NewConfig<Projection, ProjectionResponseCore>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Date, src => src.Date)
            .Map(dest => dest.Price, src => src.Price);
            
    }
}
