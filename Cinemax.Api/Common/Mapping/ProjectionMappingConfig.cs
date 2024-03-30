using Cinemax.Application.Projections.Commands.Create;
using Cinemax.Application.Projections.Commands.Delete;
using Cinemax.Application.Projections.Queries.Get;
using Cinemax.Application.Projections.Common;
using Cinemax.Contracts.Projections;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class ProjectionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
   
        config.NewConfig<ProjectionResult, ProjectionResponse>()
            .Map(dest => dest.Id, src => src.Projection.Id.Value)
            .Map(dest => dest.MovieId, src => src.Projection.MovieId.Value)
            .Map(dest => dest.RoomId, src => src.Projection.RoomId.Value)
            .Map(dest => dest.Date, src => src.Projection.Date)
            .Map(dest => dest.Price, src => src.Projection.Price);

        config.NewConfig<CreateProjectionRequest, CreateProjectionCommand>()
        .Map(dest => dest.MovieId, src => MovieId.Create(new(src.MovieId)))
        .Map(dest => dest.RoomId, src => RoomId.Create(new(src.RoomId)));

        config.NewConfig<DeleteProjectionRequest, DeleteProjectionCommand>()
            .Map(dest => dest.Id, src => ProjectionId.Create(new(src.ProjectionId)));

        config.NewConfig<GetProjectionRequest, GetProjectionQuery>()
            .Map(dest => dest.projectionId, src => ProjectionId.Create(new(src.ProjectionId)));
    }
}
