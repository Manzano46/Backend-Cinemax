using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.User.ValueObjects;
using Cinemax.Infrastructure.Migrations;
using Cinemax.Infrastructure.Services.Statistics;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class TicketRepository : ITicketRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;
    public TicketRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }
    public void Add(Ticket Ticket){
        _cinemaxDbContext.Tickets.Add(Ticket);
        _cinemaxDbContext.SaveChanges();
    }

    public Ticket? GetById(TicketId TicketId)
    {
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).SingleOrDefault(Ticket => Ticket.Id == TicketId);
    }

    public Ticket? GetTicketByKeys(SeatId seatId, UserId userId, ProjectionId projectionId, TicketStatus ticketStatus){
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).SingleOrDefault(Ticket => Ticket.SeatId == seatId && Ticket.UserId == userId && Ticket.ProjectionId == projectionId && Ticket.TicketStatus == ticketStatus); 
    }

    public IEnumerable<Ticket>? GetTicketByProjection(ProjectionId projectionId){
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).Where(t => t.ProjectionId == projectionId); 
    }

    public void Delete(TicketId TicketId){
        Ticket Ticket = _cinemaxDbContext.Tickets.SingleOrDefault(Ticket => Ticket.Id == TicketId)!;
        if(Ticket is not null){
            _cinemaxDbContext.Tickets.Remove(Ticket);
        }
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection);
    }

    public Ticket? GetTicketByKeysNoUser(SeatId seatId, ProjectionId projectionId, TicketStatus ticketStatus)
    {
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).SingleOrDefault(Ticket => Ticket.SeatId == seatId && Ticket.ProjectionId == projectionId && Ticket.TicketStatus == ticketStatus); 
    }

    public IEnumerable<Ticket>? GetTicketsReserved()
    {
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).Where(Ticket => Ticket.TicketStatus != TicketStatus.available); 
    }

    public IEnumerable<Ticket>? GetTicketsReservedByUser(UserId userId)
    {
        return _cinemaxDbContext.Tickets.Include(t => t.Seat).Include(t=>t.User).Include(t=>t.Projection).Where(Ticket => Ticket.UserId != userId); 
    }
    public async Task<List<RoomTicketCount>> GetTopRoomCountsAsync(DateTime startDate, DateTime endDate,int limit)
    {
        return await _cinemaxDbContext.Tickets
            .Include(t => t.Projection.Room)
            .Where(t => t.Date >= startDate && t.Date <= endDate)
            .GroupBy(t => new { t.Projection.Room.Id, t.Projection.Room.Name })
            .Select(g => new RoomTicketCount { RoomName = g.Key.Name, TicketCount = g.Count() })
            .OrderByDescending(x => x.TicketCount)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<List<TopMovie>> GetTopMoviesAsync(DateTime startDate, DateTime endDate,int limit)
    {
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