namespace SpotiFake.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListaReproduccion", "idTemporal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListaReproduccion", "idTemporal");
        }
    }
}
