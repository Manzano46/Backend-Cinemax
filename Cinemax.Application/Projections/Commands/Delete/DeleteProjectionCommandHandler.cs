using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Projections.Common;
using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Projections.Commands.Delete;
public class DeleteProjectionCommandHandler : IRequestHandler<DeleteProjectionCommand, ProjectionResult>
{
    private readonly IProjectionRepository _ProjectionRepository;
    public DeleteProjectionCommandHandler(IProjectionRepository projectionRepository)
    {
        _ProjectionRepository = projectionRepository;
    }
    public async Task<ProjectionResult> Handle(DeleteProjectionCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_ProjectionRepository.GetById(command.Id) is not Projection projection)
        {
            throw new Exception("Projection with given id does not exist");
        }

        _ProjectionRepository.Delete(command.Id);

        return new ProjectionResult(projection);
    }
}
