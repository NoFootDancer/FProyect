namespace FProy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lok : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        codcomp = c.String(nullable: false, maxLength: 128),
                        namec = c.String(),
                    })
                .PrimaryKey(t => t.codcomp);
            
            CreateTable(
                "dbo.Consoles",
                c => new
                    {
                        codcons = c.String(nullable: false, maxLength: 128),
                        namecons = c.String(),
                    })
                .PrimaryKey(t => t.codcons);
            
            CreateTable(
                "dbo.Factura_Game",
                c => new
                    {
                        idFolioJ = c.Int(nullable: false, identity: true),
                        idFolio = c.Int(nullable: false),
                        idjuego = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idFolioJ);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        idFolio = c.Int(nullable: false, identity: true),
                        Fecha = c.String(),
                        idStore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idFolio);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        codgen = c.String(nullable: false, maxLength: 128),
                        nameg = c.String(),
                    })
                .PrimaryKey(t => t.codgen);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        idstore = c.Int(nullable: false, identity: true),
                        nameS = c.String(),
                    })
                .PrimaryKey(t => t.idstore);
            
            AddColumn("dbo.Games", "precio", c => c.Single(nullable: false));
            AddColumn("dbo.Games", "rdate", c => c.String());
            AddColumn("dbo.Games", "codcomp", c => c.String());
            AddColumn("dbo.Games", "codcons", c => c.String(maxLength: 128));
            AddColumn("dbo.Games", "codgen", c => c.String());
            CreateIndex("dbo.Games", "codcons");
            AddForeignKey("dbo.Games", "codcons", "dbo.Consoles", "codcons");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "codcons", "dbo.Consoles");
            DropIndex("dbo.Games", new[] { "codcons" });
            DropColumn("dbo.Games", "codgen");
            DropColumn("dbo.Games", "codcons");
            DropColumn("dbo.Games", "codcomp");
            DropColumn("dbo.Games", "rdate");
            DropColumn("dbo.Games", "precio");
            DropTable("dbo.Stores");
            DropTable("dbo.Genres");
            DropTable("dbo.Facturas");
            DropTable("dbo.Factura_Game");
            DropTable("dbo.Consoles");
            DropTable("dbo.Companies");
        }
    }
}
