namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companias : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GameConsoles", newName: "ConsoleGames");
            DropPrimaryKey("dbo.ConsoleGames");
            AlterColumn("dbo.Games", "codcomp", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.ConsoleGames", new[] { "Console_codcons", "Game_idjuego" });
            CreateIndex("dbo.Games", "codcomp");
            AddForeignKey("dbo.Games", "codcomp", "dbo.Companies", "codcomp");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "codcomp", "dbo.Companies");
            DropIndex("dbo.Games", new[] { "codcomp" });
            DropPrimaryKey("dbo.ConsoleGames");
            AlterColumn("dbo.Games", "codcomp", c => c.String());
            AddPrimaryKey("dbo.ConsoleGames", new[] { "Game_idjuego", "Console_codcons" });
            RenameTable(name: "dbo.ConsoleGames", newName: "GameConsoles");
        }
    }
}
