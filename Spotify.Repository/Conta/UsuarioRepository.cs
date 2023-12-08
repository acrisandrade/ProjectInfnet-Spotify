using Spotify.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Repository.Conta
{
    public class UsuarioRepository
    {
        private static List<Usuario>usuarios = new List<Usuario>();

        public void IncluiUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            UsuarioRepository.usuarios.Add(usuario);
        }

        public Usuario ObtemUsuario(Guid id)
        {
            return UsuarioRepository.usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}
