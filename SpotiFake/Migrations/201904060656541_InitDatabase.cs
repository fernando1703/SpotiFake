namespace SpotiFake.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "rol", c => c.String());
            AddColumn("dbo.Usuario", "contraseña", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "contraseña");
            DropColumn("dbo.Usuario", "rol");
        }
    }
}
