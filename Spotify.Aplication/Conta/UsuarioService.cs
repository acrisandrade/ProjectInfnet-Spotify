using Spotify.Aplication.Conta.Dto;
using Spotify.Aplication.Streaming;
using Spotify.Core.Exception;
using Spotify.Domain.Conta.Agreggates;
using Spotify.Domain.Streaming.Aggregates;
using Spotify.Repository.Conta;
using Spotify.Repository.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Aplication.Conta
{
    public class UsuarioService
    {

        private PlanoRepository planoRepository = new PlanoRepository();


        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        private BandaService bandaService = new BandaService();


        public CriarContaDTO CriarConta(CriarContaDTO conta)
        {

            Plano plano = this.planoRepository.PegarPlanoPeloID(conta.PlanoId);

            if (plano == null)
            {
                new BussinesException(new BusinessValidation()
                { MensagemErro = "Plano não encontrado", NomeErroDefaul = nameof(CriarConta) }).TesteValidacao();
            }

            Cartao cartao = new Cartao();
            cartao.Ativo = conta.Cartao.Ativo;
            cartao.Numero = conta.Cartao.Numero;
            cartao.Limite = conta.Cartao.Limite;


            Usuario usuario = new Usuario();
            usuario.GerarUsuario(conta.Nome, conta.CPF, plano, cartao);



            //gRAVA usuarios na base de dados
            this.usuarioRepository.IncluiUsuario(usuario);
            conta.Id = usuario.Id;


            //Aqui retorna a conta que foi crida deste usuario
            return conta;
        }

        public void FavoritarMusica(Guid id, Guid idMusica)
        {//Primeiro obtenho o usuario
            var usuario = this.usuarioRepository.ObtemUsuario(id);
            if (usuario == null)
            {
                throw new BussinesException(new BusinessValidation()
                {
                    MensagemErro="usuarionao encotrado",
                    NomeErroDefaul=nameof(usuario)
                });
            }
            //obtenho a musica
            var musica = this.bandaService.ObterMusica(idMusica);
            if (musica == null)

                throw new BussinesException(new BusinessValidation()
                {
                    MensagemErro = "Musica nao encotrada",
                    NomeErroDefaul = nameof(FavoritarMusica)
                });


            usuario.Favoritar(musica);
            this.usuarioRepository.Atualizar(usuario);

        }


public CriarContaDTO ObtemUsuario(Guid id)
        {
            var usuario = this.usuarioRepository.ObtemUsuario(id);
            if (usuario == null)
                return null;

            CriarContaDTO result = new CriarContaDTO()
            {
                Id = usuario.Id,
                Cartao = new CartaoDTO()

                {
                    Ativo = usuario.Cartoes.FirstOrDefault().Ativo,
                    Limite = usuario.Cartoes.FirstOrDefault().Limite,
                    Numero = "xxxxxxxx"
                },
                CPF = usuario.CPF.NumeroFormatado(),
                Nome = usuario.Nome,
            };
            return result;  
    }
    }
}
