using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Projections.Commands.Create;
using Cinemax.Application.Projections.Common;
using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Projections.Commands.Create;
public class CreateProjectionCommandHandler : IRequestHandler<CreateProjectionCommand, ProjectionResult>
{
    private readonly IRoomRepository _RoomRepository;
    private readonly IMovieRepository _MovieRepository;
    private readonly IProjectionRepository _ProjectionRepository;

    public CreateProjectionCommandHandler(IRoomRepository roomRepository, IMovieRepository movieRepository, IProjectionRepository projectionRepository)
    {
        _RoomRepository = roomRepository;
        _MovieRepository = movieRepository;
        _ProjectionRepository = projectionRepository;
    }
    public async Task<ProjectionResult> Handle(CreateProjectionCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if(_MovieRepository.GetById(command.MovieId) is not Movie existingMovie)
        {
            throw new Exception($"Movie with id '{command.MovieId}' does not exist in the database");
        }

        if(_RoomRepository.GetById(command.RoomId) is not Room existingRoom)
        {
            throw new Exception($"Room with id '{command.RoomId}' does not exist in the database");
        }

        Projection projection = Projection.Create(
            existingMovie.Id,
            existingRoom.Id,
            command.Date,
            command.Price,
            existingMovie,
            existingRoom
            );

        _ProjectionRepository.Add(projection);

        return new ProjectionResult(projection);
    }
}
