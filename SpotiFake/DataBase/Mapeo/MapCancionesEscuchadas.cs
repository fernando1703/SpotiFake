using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpotiFake.DataBase.Mapeo
{
    public class MapCancionesEscuchadas : EntityTypeConfiguration<CancionesEscuchadas>
    {
        public MapCancionesEscuchadas()
        {
            ToTable("CancionesEscuchadas");
        }
    }
}