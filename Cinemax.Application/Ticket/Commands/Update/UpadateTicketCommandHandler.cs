using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.TicketAggregate.Entities;
using MediatR;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using Newtonsoft.Json;
using Cinemax.Application.Tickets.Common;

namespace Cinemax.Application.Tickets.Commands.Update;
public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, TicketResult>
{
    private readonly ITicketRepository _TicketRepository; 

    public UpdateTicketCommandHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;    
    }
    public async Task<TicketResult> Handle(UpdateTicketCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var ticketId = TicketId.Create(new (command.Id));
        var Ticket = _TicketRepository.GetById(ticketId);

        if (Ticket is null)
        {
            throw new Exception("Ticket with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(Ticket);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Ticket", ex);
        }
        
        _TicketRepository.Update(Ticket);

        return new TicketResult(Ticket);
    }
}