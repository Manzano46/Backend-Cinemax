using Cinemax.Domain.User;

namespace Cinemax.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator{
    string GenerateToken(User user);
}