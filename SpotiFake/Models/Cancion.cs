using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Models
{
    public class Cancion
    {
        public int idCancion { get; set; }
        public string nombre { get; set; }
        public string artista { get; set; }
        public string album { get; set; }
        public double duracionCancion { get; set; }
        public DateTime fechaLanzamiento { get; set; }

        public List<CancionesEscuchadas> cancionesEscuchadas { get; set; }
        public List<CancionesListaReproduccion> cancionesListaReproduccions { get; set; }
    }
}