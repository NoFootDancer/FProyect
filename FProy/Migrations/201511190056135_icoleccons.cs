namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class icoleccons : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "codcons", "dbo.Consoles");
            DropIndex("dbo.Games", new[] { "codcons" });
            CreateTable(
                "dbo.ConsoleGames",
                c => new
                    {
                        Console_codcons = c.String(nullable: false, maxLength: 128),
                        Game_idjuego = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Console_codcons, t.Game_idjuego })
                .ForeignKey("dbo.Consoles", t => t.Console_codcons, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_idjuego, cascadeDelete: true)
                .Index(t => t.Console_codcons)
                .Index(t => t.Game_idjuego);
            
            DropColumn("dbo.Games", "codcons");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "codcons", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ConsoleGames", "Game_idjuego", "dbo.Games");
            DropForeignKey("dbo.ConsoleGames", "Console_codcons", "dbo.Consoles");
            DropIndex("dbo.ConsoleGames", new[] { "Game_idjuego" });
            DropIndex("dbo.ConsoleGames", new[] { "Console_codcons" });
            DropTable("dbo.ConsoleGames");
            CreateIndex("dbo.Games", "codcons");
            AddForeignKey("dbo.Games", "codcons", "dbo.Consoles", "codcons");
        }
    }
}
