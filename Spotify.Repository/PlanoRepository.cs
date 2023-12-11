using Spotify.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spotify.Repository

{
    public class PlanoRepository {
        private HttpClient HttpClient { get; set; }

        public  PlanoRepository()
        {
        this.HttpClient= new HttpClient();
        }
        public async  Task <Plano> ObterPlano(Guid id)
        {
            var result = await this.HttpClient.GetAsync($"https://localhost:7218/api/Plano/{id}");
            if(result.IsSuccessStatusCode == false)
                return null;

            var content = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Plano>(content);

        }
    }
}
