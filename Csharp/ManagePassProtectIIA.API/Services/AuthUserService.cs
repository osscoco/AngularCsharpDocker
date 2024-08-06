using ManagePassProtectIIA.API.Interfaces;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace ManagePassProtectIIA.API.Services
{
    public class AuthUserService : IAuthUserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthUserService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public ArrayList AuthenticateUserAsync(string email, string password)
        {
            var responseApi = new ResponseApi();
            var passwordHash = HashString(password);
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == passwordHash);

            if (user == null)
            {
                return null;
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.Id.ToString()),
                new Claim("email", user.Email.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(60), signingCredentials: signin);
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            ArrayList arraylist = new ArrayList();
            arraylist.Add(user);
            arraylist.Add(tokenValue);
            return arraylist;
        }

        public async Task<ActionResult<ResponseApi>> PostOneUser(User user)
        {
            var passwordHash = HashString(user.Password);
            user.Password = passwordHash;
            user.Created_at = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var responseApi = new ResponseApi
            {
                Success = true,
                Data = null,
                Message = "Utilisateur créé avec succès !"
            };

            return responseApi;
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public static string HashString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir la chaîne en bytes
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Calculer le hash
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convertir le tableau de bytes en chaîne hexadécimale
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
