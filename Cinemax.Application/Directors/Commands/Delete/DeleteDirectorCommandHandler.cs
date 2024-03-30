using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Directors.Common;
using Cinemax.Domain.Director.Entities;
using MediatR;

namespace Cinemax.Application.Directors.Commands.Delete;
public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand, DirectorResult>
{
    private readonly IDirectorRepository _directorRepository; 

    public DeleteDirectorCommandHandler(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;    
    }
    public async Task<DirectorResult> Handle(DeleteDirectorCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_directorRepository.GetById(command.Id) is not Director director){
            throw new Exception("Director not found");
        }
        _directorRepository.Delete(command.Id);
        return new DirectorResult(director);
    }
}