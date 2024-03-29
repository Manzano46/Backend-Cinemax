using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Directors.Common;
using Cinemax.Domain.Director.Entities;
using MediatR;

namespace Cinemax.Application.Directors.Commands.Create;
public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, DirectorResult>
{
    private readonly IDirectorRepository _directorRepository; 

    public CreateDirectorCommandHandler(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;    
    }
    public async Task<DirectorResult> Handle(CreateDirectorCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_directorRepository.GetByName(command.Firstname,command.Lastname) is not null){
            throw new Exception("Director with given name alredy exists");
        }

        Director director = Director.Create(
            command.Firstname,
            command.Lastname
        );

        _directorRepository.Add(director);

        return new DirectorResult(director);
    }

}
