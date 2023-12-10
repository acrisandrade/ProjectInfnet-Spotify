using Spotify.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Aplication.Streaming.Dto
{
    public class BandaDto
    {
        public Guid Id { get; set; }
        [Required]//Valida requisicao
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        public List<AlbumDto> Albums { get; set; }
    }
    public class AlbumDto
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public List<MusicaDto>musicas { get; set; }
    }
    public class MusicaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
    }
}
