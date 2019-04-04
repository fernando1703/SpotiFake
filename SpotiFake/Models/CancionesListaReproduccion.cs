using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class CancionesListaReproduccion
    {
        public int id { get; set; }
        public ListaReproduccion listaReproduccion { get; set; }
        public Cancion cancion { get; set; }
    }
}