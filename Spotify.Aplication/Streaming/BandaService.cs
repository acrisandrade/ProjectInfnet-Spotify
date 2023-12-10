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
        private BandaRepository repository = new BandaRepository();
        public BandaService() { }
        public BandaDto CriaBanda(BandaDto bandadto)
        {
            Banda banda = new Banda()
            {
                Descricao = bandadto.Descricao,
                Nome = bandadto.Nome,
            };


            if (bandadto != null)
            {
                foreach (var item in bandadto.Albums)
                {
                    Album album = new Album()
                    {
                        id = Guid.NewGuid(),
                        Nome = item.Nome
                    };
                    if (item.musicas != null)
                    {
                        foreach (var musica in item.musicas)
                        {
                            album.AdicionaMusicas(new Musica()
                            {
                                Duracao = new Domain.Streaming.ValueObject.Duracao(musica.Duracao),
                                Nome = musica.Nome,
                                Album = album,
                                Id = Guid.NewGuid()
                            });

                        }
                    }
                    banda.AdicionaAlbum(album);

                }
            }

            this.repository.CriaBanda(banda);
            bandadto.Id = banda.Id;
            return bandadto;
        }

        public BandaDto ObterBanda(Guid id)
        {
            var banda = this.repository.ObtemBanda(id);

            if (banda == null)
                return null;

            BandaDto dto = new BandaDto()
            {
                Id = banda.Id,
                Descricao = banda.Descricao,
                Nome = banda.Nome,
            };

            if (banda.Albums != null)
            {
                dto.Albums = new List<AlbumDto>();

                foreach (var album in banda.Albums)
                {
                    AlbumDto albumDto = new AlbumDto()
                    {
                        id = album.id,
                        Nome = album.Nome,
                        musicas = new List<MusicaDto>()
                    };

                    album.MusicaS?.ForEach(m =>
                    {
                        albumDto.musicas.Add(new MusicaDto()
                        {
                            Id = m.Id,
                            Duracao = m.Duracao.valor,
                            Nome = m.Nome
                        });
                    });

                    dto.Albums.Add(albumDto);
                }
            }

            return dto;

        }
    }
}