using Spotify.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Repository.Streaming
{
    public class PlanoRepository
    {
        //Simular Banco
        private static List<Plano>plano;
        public PlanoRepository()
        {
            if (PlanoRepository.plano == null)
            {
                PlanoRepository.plano = new List<Plano>();

                PlanoRepository.plano.Add(new Plano()
                {
                    Descricao = "Plano 1",
                    Nome = "Plano Basico",
                    Valor = 19M,
                    Id = new Guid("b2a55062-bc07-45dc-b4b2-6754877c1c31")
                });
            }
        }
        public  Plano PegarPlanoPeloID(Guid idplano)
        {
            return PlanoRepository.plano.FirstOrDefault(x => x.Id == idplano);
        }
    }
}
