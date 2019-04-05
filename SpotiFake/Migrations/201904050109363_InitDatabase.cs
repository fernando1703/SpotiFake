namespace SpotiFake.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        idAlbum = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        fechaLanzamiento = c.DateTime(nullable: false),
                        idArtista = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idAlbum)
                .ForeignKey("dbo.Artista", t => t.idArtista, cascadeDelete: true)
                .Index(t => t.idArtista);
            
            CreateTable(
                "dbo.Artista",
                c => new
                    {
                        idArtista = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        apellido = c.String(),
                        nacionalidad = c.String(),
                    })
                .PrimaryKey(t => t.idArtista);
            
            CreateTable(
                "dbo.Cancion",
                c => new
                    {
                        idCancion = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        idAlbum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCancion)
                .ForeignKey("dbo.Album", t => t.idAlbum, cascadeDelete: true)
                .Index(t => t.idAlbum);
            
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
                "dbo.Usuario",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        correoElectronico = c.String(),
                        fechaCreación = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idUsuario);
            
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
                "dbo.CancionesListaReproduccion",
                c => new
                    {
                        idCancionesListaReproduccion = c.Int(nullable: false, identity: true),
                        idListaReproduccion = c.Int(nullable: false),
                        idCancion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCancionesListaReproduccion)
                .ForeignKey("dbo.Cancion", t => t.idCancion, cascadeDelete: true)
                .ForeignKey("dbo.ListaReproduccion", t => t.idListaReproduccion, cascadeDelete: true)
                .Index(t => t.idListaReproduccion)
                .Index(t => t.idCancion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cancion", "idAlbum", "dbo.Album");
            DropForeignKey("dbo.CancionesEscuchadas", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.ListaReproduccion", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.CancionesListaReproduccion", "idListaReproduccion", "dbo.ListaReproduccion");
            DropForeignKey("dbo.CancionesListaReproduccion", "idCancion", "dbo.Cancion");
            DropForeignKey("dbo.CancionesEscuchadas", "idCancion", "dbo.Cancion");
            DropForeignKey("dbo.Album", "idArtista", "dbo.Artista");
            DropIndex("dbo.CancionesListaReproduccion", new[] { "idCancion" });
            DropIndex("dbo.CancionesListaReproduccion", new[] { "idListaReproduccion" });
            DropIndex("dbo.ListaReproduccion", new[] { "idUsuario" });
            DropIndex("dbo.CancionesEscuchadas", new[] { "idCancion" });
            DropIndex("dbo.CancionesEscuchadas", new[] { "idUsuario" });
            DropIndex("dbo.Cancion", new[] { "idAlbum" });
            DropIndex("dbo.Album", new[] { "idArtista" });
            DropTable("dbo.CancionesListaReproduccion");
            DropTable("dbo.ListaReproduccion");
            DropTable("dbo.Usuario");
            DropTable("dbo.CancionesEscuchadas");
            DropTable("dbo.Cancion");
            DropTable("dbo.Artista");
            DropTable("dbo.Album");
        }
    }
}
