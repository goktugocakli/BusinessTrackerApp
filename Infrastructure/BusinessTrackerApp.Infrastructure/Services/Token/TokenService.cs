using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.DTOs.Employee;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessTrackerApp.Infrastructure.Services.Token
{
	public class TokenService : ITokenService
	{
        readonly IConfiguration _configuration;
        readonly UserManager<Employee> _userManager;

        public TokenService(IConfiguration configuration, UserManager<Employee> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string> CreateTokenAsync(Employee user, EmployeeDetailsDto employeeDetails)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaimsAsync(user, employeeDetails);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaimsAsync(Employee user, EmployeeDetailsDto userDetails)
        {

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("myClaimType", "deneme"),
                new Claim("DepartmentName", userDetails.DepartmentName)
            };

            if (!string.IsNullOrWhiteSpace(userDetails.TeamName))
                claims.Add(new Claim("TeamName", userDetails.TeamName));

            var roles = await  _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
                );

            return tokenOptions;
        }


    }
}

