using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.Seat.Entities;
using MediatR;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.PaymentType.Entities;

namespace Cinemax.Application.Tickets.Commands.Confirm;
public class ConfirmTicketCommandHandler : IRequestHandler<ConfirmTicketCommand, TicketResult>
{
    private readonly ITicketRepository _TicketRepository;
    private readonly IUserRepository _UserRepository;
    private readonly IProjectionRepository _ProjectionRepository;
    private readonly ISeatRepository _SeatRepository;
    private readonly IPaymentTypeRepository _PaymentTypeRepository;

    public ConfirmTicketCommandHandler(ITicketRepository TicketRepository, IUserRepository UserRepository, IProjectionRepository ProjectionRepository, ISeatRepository _seatRepository, IPaymentTypeRepository PaymentTypeRepository)
    {
        _TicketRepository = TicketRepository;
        _UserRepository = UserRepository;
        _ProjectionRepository = ProjectionRepository;
        _SeatRepository = _seatRepository;
        _PaymentTypeRepository = PaymentTypeRepository;
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


        if(_PaymentTypeRepository.GetById(command.PaymentTypeId) is not PaymentType paymentType)
        {
            throw new Exception($"PaymentType '{command.PaymentTypeId}' does not exist in the database");
        }

        if(paymentType.Name == "points" && existingUser.Points < 20)
        {
            throw new Exception($"User '{command.UserId}' does not have enough points to pay the ticket");
        }

        if(paymentType.Name == "points")
        {
            existingUser.Points -= 20;
        }

        existingUser.Points += 5;
    
        existingTicket.Date = command.Date;
        existingTicket.PaymentTypeId = command.PaymentTypeId;
        existingTicket.UserId = command.UserId;
        existingTicket.TicketStatus = TicketStatus.paid;
        _TicketRepository.Update(existingTicket);

        return new TicketResult(existingTicket);
    }
}
