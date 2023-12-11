using Spotify.Aplication.Conta.Dto;
using Spotify.Core.Exception;
using Spotify.Domain.Conta.Agreggates;
using Spotify.Repository;
using Spotify.Repository.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Aplication.Conta
{
    public class UsuarioService

    {
        private PlanoRepository planoRepository= new PlanoRepository();
        private UsuarioRepository usuarioRepository=new UsuarioRepository();
        private BandaRepository BandaRepository = new BandaRepository();
      

        
       


        public async  Task<CriarContaDTO> CriarConta(CriarContaDTO conta)
        {

            Plano plano = await this.planoRepository.ObterPlano(conta.PlanoId);

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

        public async  Task FavoritarMusica(Guid id, Guid idMusica)
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
            var musica = await  this.BandaRepository.ObterMusica(idMusica);
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
                playlistDtos = new List<playlistDto>()
            };


            foreach (var item in usuario.Playlists)
            {
                var playlist = new playlistDto() 
               
                {
                    Id = item.id,
                    Nome = item.Nome,
                    Publica = item.Publica,
                    Musicas=new List<Conta.Dto.MusicaDto>()
                };
                foreach (var musicas in item.Musicas)
                {
                    playlist.Musicas.Add(new Conta.Dto.MusicaDto()
                    {
                        Duracao = musicas.Duracao,
                        Id = musicas.Id,
                        Nome = musicas.Nome
                    });
                }
                result.playlistDtos.Add(playlist);  
            }

           

            return result;  
    }
    }
}
