using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Interface;
using MVC.Data;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using MVC.Models;

namespace MVC.Repository
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly AppDBContext _db;
        private readonly string _key;

        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }

        public JwtAuthenticationManager(AppDBContext db)
        {
            _db = db;
        }

        public string Authenticate(string username, string password)
        {
            var owner = _db.CarOwner.Any(a => a.Name == username && a.Password == password);
            var mechanic = _db.Mechanics.Any(a => a.Name == username && a.Password == password);
            bool CheckAdmin = false;

            if (username == "Admin" && password == "Admin")
            {
                CheckAdmin = true;
            }

            if (owner == false && mechanic == false && CheckAdmin == false )
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("CarManagementSystem");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                         new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
