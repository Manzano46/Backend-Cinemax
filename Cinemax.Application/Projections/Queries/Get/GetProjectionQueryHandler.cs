using System.Linq.Expressions;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Projections.Common;
using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Projections.Queries.Get;
public class GetProjectionQueryIdHandler : IRequestHandler<GetProjectionQuery, ProjectionResult>
{
    private readonly IProjectionRepository _ProjectionRepository;

    public GetProjectionQueryIdHandler(IProjectionRepository ProjectionRepository)
    {
        _ProjectionRepository = ProjectionRepository;
    }
    public async Task<ProjectionResult> Handle(GetProjectionQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var projection = _ProjectionRepository.GetById(ProjectionId.Create(new Guid(command.Id))!);
        if (projection is null)
        {
            throw new Exception("Projection not found.");
        }
        return new ProjectionResult(projection);
    }
}
