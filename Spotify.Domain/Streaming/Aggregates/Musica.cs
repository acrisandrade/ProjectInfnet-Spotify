﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming.Aggregates
{
    public class Musica
    {
        public Guid Id { get; set; }    
        public string Nome { get; set; }
        public int Duracao { get; set; }    
        public Album Album { get; set; }
        public List<Playlist> Playlists { get; set; }   
    }
}
