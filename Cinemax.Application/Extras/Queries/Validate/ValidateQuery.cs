using MediatR;

namespace Cinemax.Application.Extras.Queries.Validate;
public record ValidateQuery(
    int Cant,
    string UserId,
    string idPaymentType
) : IRequest<string>;

