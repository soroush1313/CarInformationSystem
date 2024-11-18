using AuthService.API.Configurations;
using AuthService.API.Data;
using AuthService.API.Entities;
using AuthService.API.Models;
using AuthService.API.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _context;
        private readonly JwtConfig _jwtConfig;
        private readonly ITokenService _tokenService;
        public AuthService(AuthDbContext context, IOptions<JwtConfig> jwtConfig, ITokenService tokenService)
        {
            _context = context;
            _jwtConfig = jwtConfig.Value;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse> AuthenticateUserAsync(UserLoginRequest request)
        {
            //check if user exists
            var user = await _context.Users.FindAsync(request.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }
            //generate a jwtToken
            var token = GenerateJwtToken(user);
            // Set token expiry time
            DateTime tokenExpiry = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpiryInMinutes);

            // Save the generated JWT token to MongoDB (for tracking or refresh purposes)
            string userIdAsString = user.Id.ToString();
            await _tokenService.SaveTokenAsync(userIdAsString, token, tokenExpiry);

            return new AuthResponse
            {
                Success = true,
                Token = token,
                Message = "User authenticated successfully"
            };
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpiryInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

            public async Task<AuthResponse> RegisterUserAsync(UserRegistrationRequest request)
        {
            //check if user already exists
            var existingUser = await _context.Users.FindAsync(request.UserName);
            if (existingUser != null)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "User already exists"
                };
            }

            //create new user with hashed password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var newUser = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = hashedPassword,
                Role = request.Role,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return new AuthResponse
            {
                Success = true,
                Message = "User registered successfully"
            };
        }
    }
}
