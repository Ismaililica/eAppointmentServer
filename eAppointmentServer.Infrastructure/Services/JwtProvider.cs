using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace eAppointmentServer.Infrastructure.Services
{
    internal sealed class JwtProvider : IJwtProvider
    {
        public string CreateToken(AppUser user)
        {
            JwtSecurityToken securityToken = new(issuer: "Ismail Ilica",
                audience: "eAppointment",
                claims: null,
                notBefore: null,
                expires: null,
                signingCredentials: null);

            JwtSecurityTokenHandler handler = new();

            string token = handler.WriteToken(securityToken);
            return token;
        }
    }
}
