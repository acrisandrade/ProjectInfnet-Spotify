using Spotify.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Conta.Agreggates
{
    public class Assinatura
    {
        public Guid id {  get; set; }   
        public Plano Plano { get; set; }    
        public Boolean Ativo { get; set; }    
        public DateTime DataAssinatura { get; set; }    

    }
}
