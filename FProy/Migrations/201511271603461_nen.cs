namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "rdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "rdate", c => c.String());
        }
    }
}
