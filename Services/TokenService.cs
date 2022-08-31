using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MinimalApiAuth.Models;

namespace MinimalApiAuth.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user, bool expire)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(Settings.Sectret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = expire ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddDays(999),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}