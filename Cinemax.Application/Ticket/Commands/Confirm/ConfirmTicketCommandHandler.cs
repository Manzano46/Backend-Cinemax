using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.Seat.Entities;
using MediatR;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.ProjectionAggregate;

namespace Cinemax.Application.Tickets.Commands.Confirm;
public class ConfirmTicketCommandHandler : IRequestHandler<ConfirmTicketCommand, TicketResult>
{
    private readonly ITicketRepository _TicketRepository;
    private readonly IUserRepository _UserRepository;
    private readonly IProjectionRepository _ProjectionRepository;
    private readonly ISeatRepository _SeatRepository;

    public ConfirmTicketCommandHandler(ITicketRepository TicketRepository, IUserRepository UserRepository, IProjectionRepository ProjectionRepository, ISeatRepository _seatRepository)
    {
        _TicketRepository = TicketRepository;
        _UserRepository = UserRepository;
        _ProjectionRepository = ProjectionRepository;
        _SeatRepository = _seatRepository;
    }
    
    public async Task<TicketResult> Handle(ConfirmTicketCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        User existingUser = _UserRepository.GetById(command.UserId)!;
        if (existingUser is null && command.UserId != null!)
        {
            throw new Exception($"User '{command.UserId}' does not exist in the database");
        }

        Projection existingProjection = _ProjectionRepository.GetById(command.ProjectionId)!;
        if (existingProjection is null)
        {
            throw new Exception($"Projection '{command.ProjectionId}' does not exist in the database");
        }

        Seat existingSeat = _SeatRepository.GetById(command.SeatId)!;
        if (existingSeat is null)
        {
            throw new Exception($"Seat '{command.SeatId}' does not exist in the database");
        }

        if(_TicketRepository.GetTicketByKeys(command.SeatId, command.UserId, command.ProjectionId, TicketStatus.reserved) is not Ticket existingTicket)
        {
            throw new Exception($"Seat '{command.SeatId}' is not reserved");
        }

        if(command.Date - existingTicket.Date  > TimeSpan.FromMinutes(10))
        {
            throw new Exception($"Time to confirm ticket has expired");
        }

        Ticket ticket = Ticket.Create(
            command.SeatId,
            command.UserId,
            command.ProjectionId,
            command.Date,
            TicketStatus.paid,
            existingSeat,
            existingUser,
            existingProjection
        );
        
        _TicketRepository.Add(ticket);
        _TicketRepository.Delete(existingTicket.Id);

        return new TicketResult(ticket);
    }
}
