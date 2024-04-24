using Cinemax.Application.Users.Common;
using Cinemax.Domain.User.ValueObjects;
using MediatR;

public record DeleteUserCommand(UserId Id, string idfrom) : IRequest<UserResult>;
