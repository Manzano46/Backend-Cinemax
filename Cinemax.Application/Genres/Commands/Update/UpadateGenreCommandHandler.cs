using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Genres.Common;
using Cinemax.Domain.Genre.Entities;
using MediatR;
using Cinemax.Domain.Genre.ValueObjects;
using Newtonsoft.Json;

namespace Cinemax.Application.Genres.Commands.Update;
public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, GenreResult>
{
    private readonly IGenreRepository _GenreRepository; 

    public UpdateGenreCommandHandler(IGenreRepository GenreRepository)
    {
        _GenreRepository = GenreRepository;    
    }
    public async Task<GenreResult> Handle(UpdateGenreCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var genreId = GenreId.Create(new (command.Id));
        var Genre = _GenreRepository.GetById(genreId);

        if (Genre is null)
        {
            throw new Exception("Genre with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(Genre);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Genre", ex);
        }
        
        _GenreRepository.Update(Genre);

        return new GenreResult(Genre);
    }
}