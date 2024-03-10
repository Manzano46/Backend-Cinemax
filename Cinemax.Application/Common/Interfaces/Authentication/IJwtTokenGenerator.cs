using Cinemax.Domain.Entities;

namespace Cinemax.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator{
    string GenerateToken(User user);
}