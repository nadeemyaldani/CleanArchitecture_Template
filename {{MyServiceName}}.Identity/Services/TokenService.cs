using __MyServiceName__.Identity.Domain.Entities;
using __MyServiceName__.Identity.Models;
using __MyServiceName__.Identity.Models.Auth;
using __MyServiceName__.Identity.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Identity.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IdentityContext _context;

        public TokenService(IOptions<JwtOptions> jwtOptions, IdentityContext context)
        {
            _jwtOptions = jwtOptions.Value;
            _context = context;
        }

        public AuthResult GenerateToken(ApplicationUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim("UserName", user.UserName ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                            DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.TokenExpiryInMinutes),
                signingCredentials: creds
            );

            var refreshToken = GenerateRefreshToken();

            _context.RefreshTokens.AddAsync(refreshToken).ConfigureAwait(true);
            _context.SaveChangesAsync().ConfigureAwait(true);

            var response = new AuthResult(
                  accessToken: new JwtSecurityTokenHandler().WriteToken(token),
                  accessTokenExpires: token.ValidTo,
                  refreshToken: refreshToken.Token,
                  refreshTokenExpires: refreshToken.Expires
             );

            return response;
        }
        private RefreshToken GenerateRefreshToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddDays(_jwtOptions.RefreshTokenExpiryInHours)
            };
        }

    }
}
