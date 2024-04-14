using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Directors.Common;
using Cinemax.Domain.Director.Entities;
using MediatR;
using Cinemax.Domain.Director.ValueObjects;
using Newtonsoft.Json;

namespace Cinemax.Application.Directors.Commands.Update;
public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, DirectorResult>
{
    private readonly IDirectorRepository _DirectorRepository; 

    public UpdateDirectorCommandHandler(IDirectorRepository DirectorRepository)
    {
        _DirectorRepository = DirectorRepository;    
    }
    public async Task<DirectorResult> Handle(UpdateDirectorCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var directorId = DirectorId.Create(new (command.Id));
        var Director = _DirectorRepository.GetById(directorId);

        if (Director is null)
        {
            throw new Exception("Director with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(Director);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Director", ex);
        }
        
        _DirectorRepository.Update(Director);

        return new DirectorResult(Director);
    }
}