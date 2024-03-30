using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Projections.Common;
using MediatR;

namespace Cinemax.Application.Projections.Queries.Read;
public class ReadProjectionQueryHandler : IRequestHandler<ReadProjectionQuery, IEnumerable<ProjectionResult>>
{
    private readonly IProjectionRepository _ProjectionRepository;

    public ReadProjectionQueryHandler(IProjectionRepository ProjectionRepository)
    {
        _ProjectionRepository = ProjectionRepository;
    }
    public async Task<IEnumerable<ProjectionResult>> Handle(ReadProjectionQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _ProjectionRepository.GetAll().Select(x => new ProjectionResult(x));
    }
}
