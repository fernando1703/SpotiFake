namespace SpotiFake.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cancion", "genero", c => c.String());
            AddColumn("dbo.Cancion", "imagen", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cancion", "imagen");
            DropColumn("dbo.Cancion", "genero");
        }
    }
}
