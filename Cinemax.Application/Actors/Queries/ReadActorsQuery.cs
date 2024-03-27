using Cinemax.Application.Actors.Common;
using MediatR;

namespace Cinemax.Application.Actors.Queries.Read;
public record ReadActorsQuery(
    
) : IRequest<IEnumerable<ActorResult>>;
