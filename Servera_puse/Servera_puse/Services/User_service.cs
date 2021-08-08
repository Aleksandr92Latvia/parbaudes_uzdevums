using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Servera_puse.Entities;
using Servera_puse.Helpers;
using System.Security.Cryptography;

namespace Servera_puse.Services
{
    public interface I_User_service
    {
        User Autentifikacija(string username, string password);
    }
    public class User_service: I_User_service
    {
        private readonly AppSettings _appSettings;
        private Konteksts Konteksts;

        public User_service(IOptions<AppSettings> appSettings, Konteksts konteksts)
        {
            Konteksts = konteksts;
            _appSettings = appSettings.Value;
        }

        public User Autentifikacija (string username, string password)
        {
            //autorizacija
            var algoritms = SHA256.Create();
            var user = Konteksts.Users.SingleOrDefault(x => x.Username == username && x.Password == Convert.ToBase64String(algoritms.ComputeHash(Encoding.UTF8.GetBytes(password))));

            //neveiksmiga autorizacija
            if (user == null)
                return null;

            //veiksmiga autorizacija
            else
            {
                //tokena izveidoshana
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //tokena saturs identifikators loma
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                    }),
                    //deriguma terminsh
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user.Bez_paroles();
            }

        }
    }
}
