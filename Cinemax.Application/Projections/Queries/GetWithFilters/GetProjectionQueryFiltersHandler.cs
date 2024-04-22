using System.Linq.Expressions;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Projections.Common;
using Cinemax.Domain.ProjectionAggregate;
using MediatR;

namespace Cinemax.Application.Projections.Queries.Get;
public class GetProjectionQueryHandler : IRequestHandler<GetProjectionQueryFilters, List<ProjectionResult>>
{
    private readonly IProjectionRepository _ProjectionRepository;

    public GetProjectionQueryHandler(IProjectionRepository ProjectionRepository)
    {
        _ProjectionRepository = ProjectionRepository;
    }
    public async Task<List<ProjectionResult>> Handle(GetProjectionQueryFilters command, CancellationToken cancellationToken)
    {
        List<Projection> projections = await _ProjectionRepository.GetByAsync(
            p => p.Date.CompareTo(command.DateInit.ToUniversalTime())>=0 && 
                 p.Date.CompareTo(command.DateEnd.ToUniversalTime())<=0 && 
                 p.Price >= command.MinPrice && 
                 p.Price <= command.MaxPrice);

        var projectionResults = projections.Select(p => new ProjectionResult(p)).ToList();

        return projectionResults ?? new List<ProjectionResult>();
    }
}
