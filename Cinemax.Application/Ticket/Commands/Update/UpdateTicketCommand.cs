using Cinemax.Application.Tickets.Common;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Cinemax.Application.Tickets.Commands.Update
{
    public record UpdateTicketCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<TicketResult>;
}