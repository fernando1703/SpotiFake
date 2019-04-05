using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpotiFake.DataBase.Mapeo
{
    public class MapArtista : EntityTypeConfiguration<Models.Artista>
    {
        public MapArtista()
        {
            ToTable("Artista");
            HasKey(o => o.idArtista);

            HasMany(o => o.album).WithRequired(o => o.artista).HasForeignKey(o => o.idArtista);
        }
    }
}