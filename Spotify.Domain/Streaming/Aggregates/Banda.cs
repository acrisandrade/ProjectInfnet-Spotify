﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming.Aggregates
{
    public class Banda
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<Album> Albums { get; set; }

        public Banda()
        {
                    this.Albums = new List<Album>();
        }

        public void AdicionaAlbum(Album album)
        {
            this.Albums.Add(album);

        }

    }
}
