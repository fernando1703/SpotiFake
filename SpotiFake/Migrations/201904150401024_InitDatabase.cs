namespace SpotiFake.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CancionesEscuchadas",
                c => new
                    {
                        idCancionesEscuchadas = c.Int(nullable: false, identity: true),
                        idUsuario = c.Int(nullable: false),
                        idCancion = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idCancionesEscuchadas)
                .ForeignKey("dbo.Cancion", t => t.idCancion, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idCancion);
            
            CreateTable(
                "dbo.Cancion",
                c => new
                    {
                        idCancion = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        artista = c.String(),
                        album = c.String(),
                        genero = c.String(),
                        duracionCancion = c.Double(nullable: false),
                        fechaLanzamiento = c.DateTime(nullable: false),
                        fechaRegistro = c.DateTime(nullable: false),
                        imagen = c.String(),
                    })
                .PrimaryKey(t => t.idCancion);
            
            CreateTable(
                "dbo.ListaReproduccion_Cancion",
                c => new
                    {
                        idListaReproduccion_Cancion = c.Int(nullable: false, identity: true),
                        idListaReproduccion = c.Int(nullable: false),
                        idCancion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idListaReproduccion_Cancion)
                .ForeignKey("dbo.ListaReproduccion", t => t.idListaReproduccion, cascadeDelete: true)
                .ForeignKey("dbo.Cancion", t => t.idCancion, cascadeDelete: true)
                .Index(t => t.idListaReproduccion)
                .Index(t => t.idCancion);
            
            CreateTable(
                "dbo.ListaReproduccion",
                c => new
                    {
                        idListaReproduccion = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idListaReproduccion)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        correoElectronico = c.String(),
                        dni = c.Int(nullable: false),
                        rol = c.String(),
                        contraseña = c.String(),
                        fechaCreación = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CancionesEscuchadas", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.CancionesEscuchadas", "idCancion", "dbo.Cancion");
            DropForeignKey("dbo.ListaReproduccion_Cancion", "idCancion", "dbo.Cancion");
            DropForeignKey("dbo.ListaReproduccion_Cancion", "idListaReproduccion", "dbo.ListaReproduccion");
            DropForeignKey("dbo.ListaReproduccion", "idUsuario", "dbo.Usuario");
            DropIndex("dbo.ListaReproduccion", new[] { "idUsuario" });
            DropIndex("dbo.ListaReproduccion_Cancion", new[] { "idCancion" });
            DropIndex("dbo.ListaReproduccion_Cancion", new[] { "idListaReproduccion" });
            DropIndex("dbo.CancionesEscuchadas", new[] { "idCancion" });
            DropIndex("dbo.CancionesEscuchadas", new[] { "idUsuario" });
            DropTable("dbo.Usuario");
            DropTable("dbo.ListaReproduccion");
            DropTable("dbo.ListaReproduccion_Cancion");
            DropTable("dbo.Cancion");
            DropTable("dbo.CancionesEscuchadas");
        }
    }
}
