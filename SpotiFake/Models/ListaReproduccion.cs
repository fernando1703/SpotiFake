using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class ListaReproduccion
    {
        public int idListaReproduccion { get; set; }
        public string nombre { get; set; }
        public Usuario usuario { get; set; }

        public List<CancionesListaReproduccion> cancionesListaReproduccion { get; set; }
    }
}