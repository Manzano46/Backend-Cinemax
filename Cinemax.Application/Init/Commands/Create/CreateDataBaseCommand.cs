using Cinemax.Application.Genres.Common;
using MediatR;

namespace Cinemax.Application.Init.Commands.Create;
public record CreateDataBaseCommand(
) : IRequest<string>;
