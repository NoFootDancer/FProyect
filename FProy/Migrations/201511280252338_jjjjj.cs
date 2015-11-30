namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jjjjj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "rdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "rdate", c => c.String());
        }
    }
}
