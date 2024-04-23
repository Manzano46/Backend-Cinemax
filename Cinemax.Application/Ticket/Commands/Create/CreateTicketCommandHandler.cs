using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.Seat.Entities;
using MediatR;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.ProjectionAggregate;

namespace Cinemax.Application.Tickets.Commands.Create;
public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, TicketResult>
{
    private readonly ITicketRepository _TicketRepository;
    private readonly IUserRepository _UserRepository;
    private readonly IProjectionRepository _ProjectionRepository;
    private readonly ISeatRepository _SeatRepository;

    public CreateTicketCommandHandler(ITicketRepository TicketRepository, IUserRepository UserRepository, IProjectionRepository ProjectionRepository, ISeatRepository _seatRepository)
    {
        _TicketRepository = TicketRepository;
        _UserRepository = UserRepository;
        _ProjectionRepository = ProjectionRepository;
        _SeatRepository = _seatRepository;
    }
    
    public async Task<TicketResult> Handle(CreateTicketCommand command, CancellationToken cancellationToken)
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

        if(_TicketRepository.GetTicketByKeysNoUser(command.SeatId, command.ProjectionId, TicketStatus.available) is not Ticket existingTicket)
        {
            throw new Exception($"Seat '{command.SeatId}' is not available");
        }

        existingTicket.Date = command.Date;        
        existingTicket.UserId = command.UserId!;
        existingTicket.TicketStatus = TicketStatus.reserved;
        _TicketRepository.Update(existingTicket);
        

        return new TicketResult(existingTicket);
    }
}
