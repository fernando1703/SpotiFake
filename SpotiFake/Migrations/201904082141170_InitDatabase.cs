namespace SpotiFake.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Album", "idArtista", "dbo.Artista");
            DropForeignKey("dbo.Cancion", "idAlbum", "dbo.Album");
            DropIndex("dbo.Album", new[] { "idArtista" });
            DropIndex("dbo.Cancion", new[] { "idAlbum" });
            AddColumn("dbo.Cancion", "artista", c => c.String());
            AddColumn("dbo.Cancion", "album", c => c.String());
            AddColumn("dbo.Cancion", "duracionCancion", c => c.Double(nullable: false));
            AddColumn("dbo.Cancion", "fechaLanzamiento", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cancion", "idAlbum");
            DropTable("dbo.Album");
            DropTable("dbo.Artista");
        }
        
        public override void Down()
        {
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
                "dbo.Album",
                c => new
                    {
                        idAlbum = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        fechaLanzamiento = c.DateTime(nullable: false),
                        idArtista = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idAlbum);
            
            AddColumn("dbo.Cancion", "idAlbum", c => c.Int(nullable: false));
            DropColumn("dbo.Cancion", "fechaLanzamiento");
            DropColumn("dbo.Cancion", "duracionCancion");
            DropColumn("dbo.Cancion", "album");
            DropColumn("dbo.Cancion", "artista");
            CreateIndex("dbo.Cancion", "idAlbum");
            CreateIndex("dbo.Album", "idArtista");
            AddForeignKey("dbo.Cancion", "idAlbum", "dbo.Album", "idAlbum", cascadeDelete: true);
            AddForeignKey("dbo.Album", "idArtista", "dbo.Artista", "idArtista", cascadeDelete: true);
        }
    }
}
