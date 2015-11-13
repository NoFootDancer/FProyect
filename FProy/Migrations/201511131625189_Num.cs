namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Num : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        idjuego = c.Int(nullable: false, identity: true),
                        namej = c.String(),
                    })
                .PrimaryKey(t => t.idjuego);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Games");
        }
    }
}
