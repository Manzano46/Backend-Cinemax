using Cinemax.Application.Directors.Common;
using MediatR;

namespace Cinemax.Application.Directors.Queries.Read;
public record ReadDirectorsQuery(
    
) : IRequest<IEnumerable<DirectorResult>>;
