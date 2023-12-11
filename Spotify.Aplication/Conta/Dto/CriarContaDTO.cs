using Spotify.Aplication.Conta.Dto;
using Spotify.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Aplication.Conta.Dto
{
    public class CriarContaDTO
    {
        public Guid Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String CPF { get; set; }

        [Required]
        public Guid PlanoId { get; set; }

        public CartaoDTO Cartao { get; set; }

        public List<playlistDto> playlistDtos { get; set; }
    }

    public class CartaoDTO
    {
    [Required]
    public String Numero { get; set; }

    [Required]
    public Decimal Limite { get; set; }

    [Required]
    public Boolean Ativo { get; set; }
}

    public class playlistDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Boolean Publica { get; set; }

        public List<MusicaDto>Musicas { get; set; }
    }
    public class MusicaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
    }

}
