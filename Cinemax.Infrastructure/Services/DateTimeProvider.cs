using Cinemax.Application.Common.Interfaces.Services;

namespace Cinemax.Infrastructure.Services;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}