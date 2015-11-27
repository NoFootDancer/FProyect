namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacturaGames",
                c => new
                    {
                        Factura_idFolio = c.Int(nullable: false),
                        Game_idjuego = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Factura_idFolio, t.Game_idjuego })
                .ForeignKey("dbo.Facturas", t => t.Factura_idFolio, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_idjuego, cascadeDelete: true)
                .Index(t => t.Factura_idFolio)
                .Index(t => t.Game_idjuego);
            
            DropTable("dbo.Factura_Game");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Factura_Game",
                c => new
                    {
                        idFolioJ = c.Int(nullable: false, identity: true),
                        idFolio = c.Int(nullable: false),
                        idjuego = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idFolioJ);
            
            DropForeignKey("dbo.FacturaGames", "Game_idjuego", "dbo.Games");
            DropForeignKey("dbo.FacturaGames", "Factura_idFolio", "dbo.Facturas");
            DropIndex("dbo.FacturaGames", new[] { "Game_idjuego" });
            DropIndex("dbo.FacturaGames", new[] { "Factura_idFolio" });
            DropTable("dbo.FacturaGames");
        }
    }
}
