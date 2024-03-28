using Cinemax.Application.Countries.Common;
using MediatR;

namespace Cinemax.Application.Countries.Queries.Read;
public record ReadCountriesQuery(
    
) : IRequest<IEnumerable<CountryResult>>;
