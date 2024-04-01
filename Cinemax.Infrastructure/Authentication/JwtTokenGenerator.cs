using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cinemax.Application.Common.Interfaces.Authentication;
using Cinemax.Application.Common.Interfaces.Services;
using Cinemax.Domain.User.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cinemax.Infrastructure.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private IDateTimeProvider _dateTimeProvider;
    private JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions){
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    } 
    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()!),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Birthdate, user.BirthDay.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.Name.ToString())
        };

        var securityToken = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials, issuer: _jwtSettings.Issuer, audience: _jwtSettings.Audience, expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes));

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}