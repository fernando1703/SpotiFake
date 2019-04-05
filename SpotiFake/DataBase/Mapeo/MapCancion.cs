using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpotiFake.DataBase.Mapeo
{
    public class MapCancion : EntityTypeConfiguration<Cancion>
    {
        public MapCancion()
        {
            ToTable("Cancion");
            HasKey(o => o.idCancion);

            HasRequired(o => o.album).WithMany(o => o.cancion).HasForeignKey(o => o.idAlbum);

            HasMany(o => o.cancionesListaReproduccions).WithRequired(o => o.cancion).HasForeignKey(o => o.idCancion);

            HasMany(o => o.cancionesEscuchadas).WithRequired(o => o.cancion).HasForeignKey(o => o.idCancion);
        }
    }
}