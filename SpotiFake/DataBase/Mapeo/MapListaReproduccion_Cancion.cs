using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpotiFake.DataBase.Mapeo
{
    public class MapListaReproduccion_Cancion : EntityTypeConfiguration<ListaReproduccion_Cancion>
    {
        public MapListaReproduccion_Cancion()
        {
            ToTable("ListaReproduccion_Cancion");
            HasKey(o => o.idListaReproduccion_Cancion);

            HasRequired(o => o.cancion).WithMany(o => o.listaReproduccion_Cancion).HasForeignKey(o => o.idCancion);
            HasRequired(o => o.listaReproduccion).WithMany(o => o.listaReproduccion_Cancion).HasForeignKey(o => o.idListaReproduccion);
        }
    }
}