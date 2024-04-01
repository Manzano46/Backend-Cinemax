using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.TicketAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Tickets.Commands.Delete;
public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, TicketResult>
{
    private readonly ITicketRepository _TicketRepository;
    public DeleteTicketCommandHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<TicketResult> Handle(DeleteTicketCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_TicketRepository.GetById(command.Id) is not Ticket ticket)
        {
            throw new Exception("Ticket with given id does not exist");
        }

        _TicketRepository.Delete(command.Id);

        return new TicketResult(ticket);
    }
}
