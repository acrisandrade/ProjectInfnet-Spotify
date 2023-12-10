using Spotify.Aplication.Streaming.Dto;
using Spotify.Domain.Streaming.Aggregates;
using Spotify.Repository.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Aplication.Streaming
{
    public class BandaService
    {
        private BandaRepository repository= new BandaRepository();
        public BandaService() {}
        public BandaDto CriaBanda(BandaDto bandadto)
        {
            Banda banda = new Banda()
            {
                Descricao = bandadto.Descricao,
                Nome = bandadto.Nome,
            };


            if (bandadto != null )
            {
                foreach(var item in bandadto.Albums)
                {
                    banda.AdicionaAlbum(new Album()
                    {
                        id = item.id,
                        Nome=item.Nome
                    });
                }
            }

            this.repository.CriaBanda(banda);
        }
    }
}
