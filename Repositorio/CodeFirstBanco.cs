using System;
using System.Linq;
using modelobasicoefjwt.Models;

namespace modelobasicoefjwt.Repositorio
{
    public class CodeFirstBanco
    {
        public static void Inicializar(AutenticacaoContext contexto)
        {

            if (contexto.Usuarios.Any()) return;

            var usuario = new Usuario()
            {
                Nome = "Bruno",
                Email = "brunohafonso@gmail.com",
                Senha = "bbc259521",
                DataNascimento = Convert.ToDateTime("25-04-1995"),
                CPF = "440.630.768.06"
            };

            contexto.Usuarios.Add(usuario);

            var permissao = new Permissao()
            {
                Nome = "Conversor"
            };

            contexto.Permissoes.Add(permissao);

            var usuariopermissao = new UsuarioPermissao()
            {
                IdUsuario = usuario.IdUsuario,
                IdPermissao = permissao.IdPermissao
            };

            contexto.UsuariosPermissoes.Add(usuariopermissao);
            contexto.SaveChanges();
        }
    }
}