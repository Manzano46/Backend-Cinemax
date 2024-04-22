using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using Cinemax.Domain.User.ValueObjects;
using Cinemax.Infrastructure.Services.Statistics;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class TicketRepository : Repository<Ticket,TicketId>, ITicketRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;
    public TicketRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }
    
    public void UpdateDataBase()
{
    var tenMinutesAgo = DateTime.UtcNow.AddMinutes(-10);

    var tickets = _cinemaxDbContext.Tickets
        .Where(t => t.TicketStatus == TicketStatus.reserved && t.Date <= tenMinutesAgo)
        .ToList();

    foreach (var ticket in tickets)
    {
        ticket.TicketStatus = TicketStatus.available;
    }

    _cinemaxDbContext.SaveChanges();
}
/*
    public void UpdateDataBase(){
        _cinemaxDbContext.Tickets
            .Where(t => t.TicketStatus == TicketStatus.reserved && EF.Functions.DateDiffMinute(t.Date,DateTime.UtcNow) > 10)
            .ExecuteUpdate(t => t.SetProperty(ticket => ticket.TicketStatus, TicketStatus.available));

        _cinemaxDbContext.SaveChanges();
    }*/

    public override Ticket? GetById(TicketId TicketId)
    {
        UpdateDataBase();
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).SingleOrDefault(Ticket => Ticket.Id == TicketId);
    }

    public Ticket? GetTicketByKeys(SeatId seatId, UserId userId, ProjectionId projectionId, TicketStatus ticketStatus){
        UpdateDataBase();
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).SingleOrDefault(Ticket => Ticket.SeatId == seatId && Ticket.UserId == userId && Ticket.ProjectionId == projectionId && Ticket.TicketStatus == ticketStatus); 
    }

    public IEnumerable<Ticket>? GetTicketByProjection(ProjectionId projectionId){
        UpdateDataBase();
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).Where(t => t.ProjectionId == projectionId); 
    }


    public override IEnumerable<Ticket> GetAll()
    {
        UpdateDataBase();
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection);
    }

    public Ticket? GetTicketByKeysNoUser(SeatId seatId, ProjectionId projectionId, TicketStatus ticketStatus)
    {
        UpdateDataBase();
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).SingleOrDefault(Ticket => Ticket.SeatId == seatId && Ticket.ProjectionId == projectionId && Ticket.TicketStatus == ticketStatus); 
    }

    public IEnumerable<Ticket>? GetTicketsReserved()
    {
        UpdateDataBase();
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).Where(Ticket => Ticket.TicketStatus != TicketStatus.available); 
    }

    public IEnumerable<Ticket>? GetTicketsReservedByUser(UserId userId)
    {
        UpdateDataBase();
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).Where(Ticket => Ticket.UserId != userId); 
    }
    public async Task<List<RoomTicketCount>> GetTopRoomCountsAsync(DateTime startDate, DateTime endDate,int limit)
    {
        UpdateDataBase();
        return await _cinemaxDbContext.Tickets
            .Include(t => t.Projection.Room)
            .Where(t => t.Date >= startDate && t.Date <= endDate && t.TicketStatus == TicketStatus.paid)
            .GroupBy(t => new { t.Projection.Room.Id, t.Projection.Room.Name })
            .Select(g => new RoomTicketCount { RoomName = g.Key.Name, TicketCount = g.Count(), Sales = g.Sum(t => t.Projection.Price) })
            .OrderByDescending(x => x.TicketCount)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<List<TopMovie>> GetTopMoviesAsync(DateTime startDate, DateTime endDate,int limit)
    {
        UpdateDataBase();
        return await _cinemaxDbContext.Tickets
            .Include(t => t.Projection.Movie)
            .Where(t => t.Date >= startDate && t.Date <= endDate)
            .GroupBy(t => new { t.Projection.Movie.Id, t.Projection.Movie.Name })
            .Select(g => new TopMovie { Name = g.Key.Name, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(limit)
            .ToListAsync();
    }
}