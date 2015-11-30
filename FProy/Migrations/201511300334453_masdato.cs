namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class masdato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "datos", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facturas", "datos");
        }
    }
}
