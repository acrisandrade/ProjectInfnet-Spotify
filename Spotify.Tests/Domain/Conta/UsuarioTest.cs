using Spotify.Domain.Conta.Agreggates;
using Spotify.Domain.Conta.Exception;
using Spotify.Domain.Streaming.Aggregates.SpotifyLike.Domain.Streaming.Aggregates;
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
        [Fact]
        public void CriarUsuarioComSucesso()
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
                Ativo = true,
                Limite = 1500M,
                Numero = "0123456789"
            };

            //Act
            string cpf = "774.646.510-22";
            string nome = "Léia";

            //Assert
            Usuario usuario = new Usuario();
            usuario.GerarUsuario(nome, cpf, plano, cartao);
            Assert.NotNull(usuario.CPF);
            Assert.NotNull(usuario.Nome);
            Assert.True(usuario.CPF.Numero == cpf);
            Assert.True(usuario.Nome == nome);

            Assert.True(usuario.Assinaturas.Count > 0);
            Assert.Same(usuario.Assinaturas[0].Plano, plano);

            Assert.True(usuario.Cartoes.Count > 0);
            Assert.Same(usuario.Cartoes[0], cartao);

            Assert.True(usuario.Playlists.Count > 0);
            Assert.True(usuario.Playlists[0].Nome == "Favoritas");
            Assert.False(usuario.Playlists[0].Publica);
        }

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
            public void NaoCriaTransacaocomCartaoInvalido()
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

        }


        }
}
