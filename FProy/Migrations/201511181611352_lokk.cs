namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lokk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "codgen", c => c.String(maxLength: 128));
            CreateIndex("dbo.Games", "codgen");
            AddForeignKey("dbo.Games", "codgen", "dbo.Genres", "codgen");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "codgen", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "codgen" });
            AlterColumn("dbo.Games", "codgen", c => c.String());
        }
    }
}
