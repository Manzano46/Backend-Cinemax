using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Projections.Common;
using MediatR;

namespace Cinemax.Application.Projections.Queries.Get;
public class GetProjectionQueryHandler : IRequestHandler<GetProjectionQuery, ProjectionResult>
{
    private readonly IProjectionRepository _ProjectionRepository;

    public GetProjectionQueryHandler(IProjectionRepository ProjectionRepository)
    {
        _ProjectionRepository = ProjectionRepository;
    }
    public async Task<ProjectionResult> Handle(GetProjectionQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_ProjectionRepository.GetById(command.projectionId)!);
    }
}
