using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class CancionesEscuchadas
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public Cancion cancion { get; set; }
        public DateTime fecha { get; set; }
    }
}