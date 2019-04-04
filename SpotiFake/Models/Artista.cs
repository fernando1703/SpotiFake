using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class Artista
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nacionalidad { get; set; }

        public List<Album> album { get; set; }
    }
}