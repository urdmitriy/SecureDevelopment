using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SecureDevelopment.Model;
using SecureDevelopment.Repository;

namespace SecureDevelopment.Services
{
    public class Authorization : IAuthorization
    {
        private readonly IRepositoryUser _repositoryUser;

        public Authorization(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public string GetTokenKey(UserAccount user)
        {
            var result = _repositoryUser.GetUser(user);
            return result == null ? "None" : GenerateToken(result);
        }

        private static string GenerateToken(UserAccount user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            var now = DateTime.UtcNow;
            
            var jwt = new JwtSecurityToken(
                issuer:AuthOptions.Issuer,
                audience:AuthOptions.Audience,
                notBefore:now,
                claims: claims,
                expires:now.Add(TimeSpan.FromMinutes(AuthOptions.LifeTime)),
                signingCredentials:new SigningCredentials(
                    AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
            );

            var encodedJwc = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwc;
        }
    }
}