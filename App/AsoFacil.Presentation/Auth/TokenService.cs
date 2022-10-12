using AsoFacil.Application.Models.Usuario;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AsoFacil.Presentation.Auth
{
    public class TokenService
    {
        public string GerarToken(UsuarioModel model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Config.JwtKey);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid, model.Id.ToString()),
                new Claim("COD_TIPO_USUARIO", model.TipoUsuario.Codigo),
                new Claim("EMPRESA_ID", model.Empresa.Id.ToString()),
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    algorithm: SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}