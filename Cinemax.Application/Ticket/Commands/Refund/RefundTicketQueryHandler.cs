using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.User.Entities;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.Refund;
public class RefundTicketQueryHandler : IRequestHandler<RefundTicketQuery, TicketResult>
{
    private readonly ITicketRepository _TicketRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPaymentTypeRepository _PaymentTypeRepository;
    private readonly IProjectionRepository _projectionRepository;

    public RefundTicketQueryHandler(ITicketRepository TicketRepository, IUserRepository userRepository, IPaymentTypeRepository PaymentTypeRepository, IProjectionRepository projectionRepository)
    {
        _TicketRepository = TicketRepository;
        _userRepository = userRepository;
        _PaymentTypeRepository = PaymentTypeRepository;
        _projectionRepository = projectionRepository;
    }
    public async Task<TicketResult> Handle(RefundTicketQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var ticket = _TicketRepository.GetById(command.TicketId);
        
        if (ticket is null)
        {
            throw new Exception($"Ticket '{command.TicketId}' does not exist in the database");
        }
        if(_userRepository.GetById(ticket.UserId) is not User existingUser)
        {
            throw new Exception($"User '{ticket.UserId}' does not exist in the database");
        }
        if(_PaymentTypeRepository.GetById(ticket.PaymentTypeId) is not PaymentType existingPaymentType)
        {
            throw new Exception($"PaymentType '{ticket.PaymentTypeId}' does not exist in the database");
        }
        if(_projectionRepository.GetById(ticket.ProjectionId) is not Projection projection)
        {
            throw new Exception($"Projection {ticket.ProjectionId} does not exist in the database");
        }

        if((projection.Date - DateTime.UtcNow).TotalHours <= 2 || DateTime.UtcNow > projection.Date)
        {
            throw new Exception("Time expired to refund");
        }

        if(existingPaymentType.Name == "points"){
            existingUser.Points += 10;
        }

        ticket.UserId = null;
        ticket.PaymentTypeId = null;
        ticket.TicketStatus = Domain.TicketAggregate.Entities.TicketStatus.available;
        _userRepository.Update(existingUser);
        _TicketRepository.Update(ticket);
        return new TicketResult(ticket);
    }
}
