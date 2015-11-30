namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechafact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Facturas", "Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Facturas", "Fecha", c => c.String());
        }
    }
}
