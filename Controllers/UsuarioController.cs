using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using modelobasicoefjwt.Models;
using modelobasicoefjwt.Repositorio;

namespace modeloaulaefjwt.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        readonly AutenticacaoContext context;

        public UsuarioController(AutenticacaoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Usuario> Get()
        {
            return context.Usuarios.ToList();
        }
    }
}