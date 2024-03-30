using Cinemax.Application.Directors.Common;
using Cinemax.Domain.Director.ValueObjects;
using MediatR;

namespace Cinemax.Application.Directors.Queries.Get;
public record GetDirectorQuery(
    DirectorId DirectorId
) : IRequest<DirectorResult>;
