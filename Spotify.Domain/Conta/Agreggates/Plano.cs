using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Conta.Agreggates
{
    public class Plano
    {
        public Guid id {  get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set;}
        public Decimal Valor { get; set;}   
    }
}
