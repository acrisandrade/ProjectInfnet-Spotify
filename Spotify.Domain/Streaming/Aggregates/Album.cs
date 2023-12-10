using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming.Aggregates
{
    public class Album
    {
        public Guid id {  get; set; }   
        public string Nome { get; set; }    
        public Banda  Banda{ get; set; }

        public List<Musica> MusicaS { get; set;} 

        public Album() { 
        this.MusicaS = new List<Musica>();  
         }

        //Adiciona lista de musica
        public void AdicionaMusicas(List<Musica> musicaS) {
            this.MusicaS.AddRange(musicaS);
        }
//Adiciona uma musica
        public void AdicionaMusicas(Musica musicaS)
        {
            this.MusicaS.Add(musicaS);
        }

    }
}
