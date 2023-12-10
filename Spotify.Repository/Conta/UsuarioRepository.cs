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

        public void Atualizar(Usuario usuario)
        {
            Usuario UsuarioAntigo = this.ObtemUsuario(usuario.Id);
            UsuarioRepository.usuarios.Remove(UsuarioAntigo);
            UsuarioRepository.usuarios.Add(UsuarioAntigo);
        }

        public void IncluiUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            UsuarioRepository.usuarios.Add(usuario);
        }

        public object ObtemMusica(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtemUsuario(Guid id)
        {
            return UsuarioRepository.usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}
