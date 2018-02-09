using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using modeloaulaefjwt.Models;
using modeloaulaefjwt.Repositorio;
using modelobasicoefjwt.Models;
using modelobasicoefjwt.Repositorio;

namespace modeloaulaefjwt.Controllers
{
    [Route("api/[Controller]")]
    public class LoginController : Controller
    {
        readonly AutenticacaoContext context;

        public LoginController(AutenticacaoContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Validar([FromBody] Usuario usuario, [FromServices] SigningConfigurations signingConfigurations, [FromServices] TokenConfigurations tokenConfigurations)
        {
            Usuario user = context.Usuarios.FirstOrDefault(c => c.Email == usuario.Email && c.Senha == usuario.Senha);
            if (user != null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.IdUsuario.ToString(), "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.IdUsuario.ToString()),
                        new Claim("Nome", user.Nome),
                        new Claim(ClaimTypes.Email, user.Email)
                    }
                );

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity
                });

                var token = handler.WriteToken(securityToken);
                var retorno = new
                {
                    autenticacao = true,
                    acessToken = token,
                    message = "Ok"
                };

                return Ok(retorno);
            }

            var retornoerro = new
            {
                autenticacao = false,
                message = "Falha na Autenticação"
            };

            return BadRequest(retornoerro);
        }
    }
}