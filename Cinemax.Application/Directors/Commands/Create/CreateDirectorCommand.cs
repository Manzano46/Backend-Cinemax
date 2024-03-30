using Cinemax.Application.Directors.Common;
using Cinemax.Domain.Director.ValueObjects;
using MediatR;

namespace Cinemax.Application.Directors.Commands.Create;
public record CreateDirectorCommand(
    string Firstname,
    string Lastname
) : IRequest<DirectorResult>;

