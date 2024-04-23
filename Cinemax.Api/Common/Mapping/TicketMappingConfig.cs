using Cinemax.Application.Tickets.Commands.Create;
using Cinemax.Application.Tickets.Commands.Delete;
using Cinemax.Application.Tickets.Common;
using Cinemax.Application.Tickets.Queries.Get;
using Cinemax.Contracts.Tickets;
using Cinemax.Contracts.Seats;
using Cinemax.Domain.Seat.Entities;
using Mapster;
using MapsterMapper;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.User.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Application.Tickets.Commands.Confirm;

namespace Cinemax.Api.Common.Mapping;
public class TicketMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){

        config.NewConfig<TicketResult, TicketResponse>()
            .Map(dest => dest.Id, src => src.Ticket.Id.Value)
            .Map(dest => dest.SeatId, src => src.Ticket.SeatId.Value)
            .Map(dest => dest.UserId, src => src.Ticket.UserId.Value)
            .Map(dest => dest.ProjectionId, src => src.Ticket.ProjectionId.Value)
            .Map(dest => dest.Date, src => src.Ticket.Date)
            .Map(dest => dest.TicketStatus, src => src.Ticket.TicketStatus)
            .Map(dest => dest.Seat, src => src.Ticket.Seat)
            .Map(dest => dest.User, src => src.Ticket.User)
            .Map(dest => dest.Projection, src => src.Ticket.Projection)
            .Map(dest => dest.PaymentTypeId, src => src.Ticket.PaymentTypeId.Value != null ? src.Ticket.PaymentTypeId.Value.ToString() : "Vacio")
            .Map(dest => dest.PaymentType, src => src.Ticket.PaymentType);
        
        config.NewConfig<CreateTicketRequest, CreateTicketCommand>()
            .Map(dest => dest.SeatId, src => SeatId.Create(new(src.SeatId)))
            .Map(dest => dest.UserId, src => UserId.Create(new(src.UserId)))
            .Map(dest => dest.ProjectionId, src => ProjectionId.Create(new(src.ProjectionId)));
            
        config.NewConfig<ConfirmTicketRequest, ConfirmTicketCommand>()
            .Map(dest => dest.SeatId, src => SeatId.Create(new(src.SeatId)))
            .Map(dest => dest.UserId, src => UserId.Create(new(src.UserId)))
            .Map(dest => dest.ProjectionId, src => ProjectionId.Create(new(src.ProjectionId)));
          

        config.NewConfig<DeleteTicketRequest, DeleteTicketCommand>()
            .Map(dest => dest.Id, src => TicketId.Create(new(src.Id)));

        config.NewConfig<GetTicketRequest, GetTicketQuery>()
            .Map(dest => dest.TicketId, src => TicketId.Create(new(src.Id)));
        
        config.NewConfig<Ticket, TicketResponseCore>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.SeatId, src => src.SeatId.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.Date, src => src.Date)
            .Map(dest => dest.TicketStatus, src => src.TicketStatus);

        
    }
}
