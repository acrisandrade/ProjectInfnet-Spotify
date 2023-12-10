using Spotify.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Repository.Streaming
{
    public class BandaRepository
    {
        private static List<Banda> bandas = new List<Banda>();

        public void CriaBanda(Banda banda)
        {
            banda.Id = Guid.NewGuid();
            bandas.Add(banda);
        }

        public Banda ObtemBanda(Guid id)
        {
            return bandas.FirstOrDefault(x => x.Id == id);
        }

        public Musica ObterMusica(Guid idMusica)
        {
            Musica result = null;

            foreach (var banda in bandas)
            {
                foreach (var album in banda.Albums)
                {
                    result = album.MusicaS.FirstOrDefault(x => x.Id == idMusica);

                    if (result != null)
                        break;
                }
            }
            return result;
        }
    }
}