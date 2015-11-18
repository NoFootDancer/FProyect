namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class consolas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "codcons", "dbo.Consoles");
            DropIndex("dbo.Games", new[] { "codcons" });
            CreateTable(
                "dbo.GameConsoles",
                c => new
                    {
                        Game_idjuego = c.Int(nullable: false),
                        Console_codcons = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Game_idjuego, t.Console_codcons })
                .ForeignKey("dbo.Games", t => t.Game_idjuego, cascadeDelete: true)
                .ForeignKey("dbo.Consoles", t => t.Console_codcons, cascadeDelete: true)
                .Index(t => t.Game_idjuego)
                .Index(t => t.Console_codcons);
            
            DropColumn("dbo.Games", "codcons");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "codcons", c => c.String(maxLength: 128));
            DropForeignKey("dbo.GameConsoles", "Console_codcons", "dbo.Consoles");
            DropForeignKey("dbo.GameConsoles", "Game_idjuego", "dbo.Games");
            DropIndex("dbo.GameConsoles", new[] { "Console_codcons" });
            DropIndex("dbo.GameConsoles", new[] { "Game_idjuego" });
            DropTable("dbo.GameConsoles");
            CreateIndex("dbo.Games", "codcons");
            AddForeignKey("dbo.Games", "codcons", "dbo.Consoles", "codcons");
        }
    }
}
