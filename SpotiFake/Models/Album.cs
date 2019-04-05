using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class Album
    {
        public int idAlbum { get; set; }
        public string nombre { get; set; }
        public DateTime fechaLanzamiento { get; set; }

        public int idArtista { get; set; }
        public Artista artista { get; set; }
        
        public List<Cancion> cancion { get; set; }
    }
}