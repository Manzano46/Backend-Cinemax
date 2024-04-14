using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Projections.Common;
using MediatR;
using Newtonsoft.Json;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Application.Projections.Commands.Update;
public class UpdateProjectionCommandHandler : IRequestHandler<UpdateProjectionCommand, ProjectionResult>
{
    private readonly IProjectionRepository _ProjectionRepository; 

    public UpdateProjectionCommandHandler(IProjectionRepository ProjectionRepository)
    {
        _ProjectionRepository = ProjectionRepository;    
    }
    public async Task<ProjectionResult> Handle(UpdateProjectionCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var projectionId = ProjectionId.Create(new (command.Id));
        var Projection = _ProjectionRepository.GetById(projectionId);

        if (Projection is null)
        {
            throw new Exception("Projection with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(Projection);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Projection", ex);
        }
        
        _ProjectionRepository.Update(Projection);

        return new ProjectionResult(Projection);
    }
}