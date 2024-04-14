using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.Entities;
using Cinemax.Domain.Seat.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class SeatRepository : Repository<Seat,SeatId>, ISeatRepository{
    public SeatRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
    }
}
