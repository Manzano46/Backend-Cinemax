using Cinemax.Application.Directors.Common;
using Cinemax.Domain.Director.ValueObjects;
using MediatR;

public record DeleteDirectorCommand(DirectorId Id) : IRequest<DirectorResult>;
