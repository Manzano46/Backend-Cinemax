using System.Linq.Expressions;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Projections.Common;
using Cinemax.Domain.ProjectionAggregate;
using MediatR;

namespace Cinemax.Application.Projections.Queries.Get;
public class GetProjectionQueryMovieHandler : IRequestHandler<GetProjectionQueryMovie, List<ProjectionResult>>
{
    private readonly IProjectionRepository _ProjectionRepository;

    public GetProjectionQueryMovieHandler(IProjectionRepository ProjectionRepository)
    {
        _ProjectionRepository = ProjectionRepository;
    }
    public async Task<List<ProjectionResult>> Handle(GetProjectionQueryMovie command, CancellationToken cancellationToken)
    {
        List<Projection> projections = await _ProjectionRepository.GetByAsync(m => m.MovieId == command.MovieId);

        var projectionResults = projections.Select(p => new ProjectionResult(p)).ToList();

        return projectionResults ?? new List<ProjectionResult>();
    }
}
