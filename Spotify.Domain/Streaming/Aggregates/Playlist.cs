using Spotify.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming.Aggregates
{
    public class Playlist
    {
        public Guid id {  get; set; }
        public string Nome { get; set; }
        public Boolean Publica { get; set; }    
        public Usuario Usuario { get; set; }    
        public List<Musica> Musicas { get;}


    }
}
