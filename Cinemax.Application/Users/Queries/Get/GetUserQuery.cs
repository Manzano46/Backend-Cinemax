using Cinemax.Application.Users.Common;
using Cinemax.Domain.User.ValueObjects;
using MediatR;

namespace Cinemax.Application.Users.Queries.Get;
public record GetUserQuery(
    UserId UserId
) : IRequest<UserResult>;
