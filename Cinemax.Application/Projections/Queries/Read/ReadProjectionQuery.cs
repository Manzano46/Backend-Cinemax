using Cinemax.Application.Projections.Common;
using MediatR;

namespace Cinemax.Application.Projections.Queries.Read;
public record ReadProjectionQuery(

) : IRequest<IEnumerable<ProjectionResult>>;
