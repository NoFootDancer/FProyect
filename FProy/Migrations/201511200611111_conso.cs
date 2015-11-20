namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conso : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsoleGames", "Console_codcons", "dbo.Consoles");
            DropForeignKey("dbo.ConsoleGames", "Game_idjuego", "dbo.Games");
            DropIndex("dbo.ConsoleGames", new[] { "Console_codcons" });
            DropIndex("dbo.ConsoleGames", new[] { "Game_idjuego" });
            AddColumn("dbo.Games", "codcons", c => c.String(maxLength: 128));
            CreateIndex("dbo.Games", "codcons");
            AddForeignKey("dbo.Games", "codcons", "dbo.Consoles", "codcons");
            DropTable("dbo.ConsoleGames");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ConsoleGames",
                c => new
                    {
                        Console_codcons = c.String(nullable: false, maxLength: 128),
                        Game_idjuego = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Console_codcons, t.Game_idjuego });
            
            DropForeignKey("dbo.Games", "codcons", "dbo.Consoles");
            DropIndex("dbo.Games", new[] { "codcons" });
            DropColumn("dbo.Games", "codcons");
            CreateIndex("dbo.ConsoleGames", "Game_idjuego");
            CreateIndex("dbo.ConsoleGames", "Console_codcons");
            AddForeignKey("dbo.ConsoleGames", "Game_idjuego", "dbo.Games", "idjuego", cascadeDelete: true);
            AddForeignKey("dbo.ConsoleGames", "Console_codcons", "dbo.Consoles", "codcons", cascadeDelete: true);
        }
    }
}
