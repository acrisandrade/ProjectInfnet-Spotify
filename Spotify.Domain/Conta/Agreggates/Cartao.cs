using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Conta.Agreggates
{
    internal class Cartao
    {
        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }    
        public Decimal Limite { get; set;}
        public string NumeroCartao { get; set; } 
        public List<Transacao.Agreggates.Transacao>?Transacoes { get; set; }

    }
}
