
using Spotify.Domain.Conta.ValueObject;
using Spotify.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Conta.Agreggates
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public Spotify.Domain.Conta.ValueObject.CPF CPF { get; set; }

        public List <Cartao> Cartoes { get; set;}

        public List <Playlist> Playlists { get; set; }
        public  List <Banda> BandasFavoritas { get; set; }    

        public List <Assinatura>Assinaturas {  get; set; }    
  

        public Usuario()
        {
            this.Playlists = new List<Playlist>();
            this.BandasFavoritas = new List<Banda>();
            this.Assinaturas = new List<Assinatura>();
            this.Cartoes = new List<Cartao>(); 

        }


    public void GerarUsuario(string nome,string cpf, Plano plano,Cartao cartao)
        {
            this.CPF = new CPF(cpf);
            this.Nome = nome;
           


            //Assina plano
            this.AssinarPlano(plano, cartao);
            //Adiciona o cartao na conta 
            this.AdicionaCartao(cartao);
            //cria playlist
            this.CriarPlaylist();

        }



      


        //Gerar uma Playlist default
        public void CriarPlaylist(string nome = "Favoritas")
        {
            this.Playlists.Add(new Playlist()
            {
                id = Guid.NewGuid(),
                Nome = nome,
                Publica = false,
                Usuario = this
            });
        }

public void Favoritar(Musica musica)
        {
            this.Playlists.FirstOrDefault(x => x.Nome == "Favoritas").Musicas.Add(musica);
        }


        private void AdicionaCartao(Cartao cartao)
        {
            this.Cartoes.Add(cartao);

        }



        public void AssinarPlano(Plano plano,Cartao cartao)
        {
                   //Debita o valor do plano no cartao
            cartao.CriarTransacao(plano.Nome, plano.Valor, plano.Descricao);

            //Desativa a assinatura se ja tiver uma
            if(this.Assinaturas.Count > 0 && this.Assinaturas.Any(x => x.Ativo))
            {
                var planoAtivo = this.Assinaturas.FirstOrDefault(x => x.Ativo);
                planoAtivo.Ativo = false;
            }
            //Insere nova assinatura
            this.Assinaturas.Add(new Assinatura()
            {

                Ativo = true,
                DataAssinatura = DateTime.Now,
                Plano = plano,
                id = Guid.NewGuid()
            });
        }
    
    
    
    }

}
