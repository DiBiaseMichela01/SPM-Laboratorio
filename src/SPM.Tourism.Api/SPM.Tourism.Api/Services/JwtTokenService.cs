using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SPM.Tourism.Api.Models;

namespace SPM.Tourism.Api.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            // Read the secret key from configuration
            string jwtKey = _configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT signing key is missing.");

            // Prepare the signing credentials
            byte[] keyBytes = Convert.FromBase64String(jwtKey);
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            // Define the user information included in the token
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email)
    };

            // Create a JWT valid for one hour
            var token = new JwtSecurityToken(
                issuer: "SPM.Tourism.Api",
                audience: "SPM.Tourism.PWA",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            // Convert the JWT into a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }


}
