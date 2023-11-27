using Spotify.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Transacao.Agreggates
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public DateTime DtTransacao { get; set; }
        public Decimal ValorTransacao { get; set; }
        public Merchant Merchant { get; set; }  
        public string Descricao {  get; set; }  
    }
}
