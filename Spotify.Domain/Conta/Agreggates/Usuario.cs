using Spotify.Domain.Conta.ValueObject;
using Spotify.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Conta.Agreggates
{
    internal class Usuario
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public CPF CPF { get; set; }

        public List <Cartao> Cartoes { get; set;}

        public List <Playlist> Playlists { get; set; }
        public  List <Banda> BandasFavoritas { get; set; }    
    }

}
