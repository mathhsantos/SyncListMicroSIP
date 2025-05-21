using Microsoft.IdentityModel.Tokens;
using SyncListMicroSIP.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SyncListMicroSIP.Service
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(string number)
        {

            // Precisa encodar a key privada em array de byte
            byte[] key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Key"));

            // Construo meu token com as claims, expires e credentials
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("Number", number)
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // instancio meu handler para criar o token
            var tokenHandler = new JwtSecurityTokenHandler();

            // Crio o token
            var token = tokenHandler.CreateToken(tokenConfig);

            // Escrevo o token em string e retorno
            return tokenHandler.WriteToken(token);
        }
    }
}
