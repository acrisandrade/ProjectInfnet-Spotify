using Spotify.Domain.Conta.Agreggates;
using Spotify.Domain.Conta.Exception;
using Spotify.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Spotify.Tests.Domain.Conta
{
    public class UsuarioTest
    {
   

        [Fact()]
        public void NaoCriaUsuarioomCpfInvalido()
        {
            Plano plano = new Plano()
            {
                Descricao = "Aqui você encontra todo tipo de muica.",
                Id = Guid.NewGuid(),
                Nome = "Stars",
                Valor = 19.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = false,
                Limite = 1500M,
                Numero = "1234567890"
            };

            //Act
            string cpf = "0123456789";
            string nome = "Léia";
            Usuario usuario = new Usuario();

            Assert.Throws<CPFException>(() => usuario.GerarUsuario(nome, cpf, plano, cartao));


        }

        [Fact()]
        public void NaoCriaUsuariocomCartaoInvalido()
        {
            Plano plano = new Plano()
            {
                Descricao = "Lorem ipsum",
                Id = Guid.NewGuid(),
                Nome = "star",
                Valor = 19.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = false,
                Limite = 1000M,
                Numero = "1234567890",
            };

            string cpf = "774.646.510-22";
            string nome = "Léia";
            Usuario usuario = new Usuario();

            Assert.Throws<CartaoException>
                (() => usuario.GerarUsuario(nome, cpf, plano, cartao));

        }
    }


}
