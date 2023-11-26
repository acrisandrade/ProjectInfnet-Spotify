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
    }
}
