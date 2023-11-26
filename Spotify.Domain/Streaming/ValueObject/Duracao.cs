using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming.ValueObject
{
    public class Duracao
    {
        public int valor {  get; set; }
        public Duracao(int valor)
        {
            if (valor < 0)
                throw new ArgumentException("A Duracao nao pode ser menor que Zero");
            this.valor = valor; 
        }

        public string DuracaoFormatada()
        {
            int minutos = valor * 60;
            int segundos = valor % 60;

            return $"{minutos.ToString().PadLeft(1, '0')}min:{segundos.ToString().PadLeft(1, '0')}seg";

        }
    }
}
