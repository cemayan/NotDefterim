namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeni : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arkadasliks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Uyeler_ID = c.Guid(nullable: false),
                        Uyeler2_ID = c.Guid(nullable: false),
                        Durum = c.Boolean(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Uyelers", t => t.Uyeler2_ID, cascadeDelete: true)
                .Index(t => t.Uyeler2_ID);
            
            CreateTable(
                "dbo.Uyelers",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true,defaultValueSql:"newsequentialid()"),
                        Ad = c.String(),
                        Soyad = c.String(),
                        KullaniciAdi = c.String(),
                        Email = c.String(),
                        Sifre = c.String(),
                        ArkaPlan = c.String(),
                        Resim = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Paylasimlars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Paylasim = c.String(),
                        PaylasimResim = c.String(),
                        PaylasimVideo = c.String(),
                        Begen = c.Int(nullable: false),
                        Favori = c.Int(nullable: false),
                        PaylasimTur_ID = c.Int(nullable: false),
                        Uyeler_ID = c.Guid(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PaylasimTurs", t => t.PaylasimTur_ID, cascadeDelete: true)
                .ForeignKey("dbo.Uyelers", t => t.Uyeler_ID, cascadeDelete: true)
                .Index(t => t.PaylasimTur_ID)
                .Index(t => t.Uyeler_ID);
            
            CreateTable(
                "dbo.PaylasimTurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Gundems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Sayac = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UGundems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Uyeler_ID = c.Guid(nullable: false),
                        Gundem_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gundems", t => t.Gundem_ID, cascadeDelete: true)
                .ForeignKey("dbo.Uyelers", t => t.Uyeler_ID, cascadeDelete: true)
                .Index(t => t.Uyeler_ID)
                .Index(t => t.Gundem_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UGundems", "Uyeler_ID", "dbo.Uyelers");
            DropForeignKey("dbo.UGundems", "Gundem_ID", "dbo.Gundems");
            DropForeignKey("dbo.Arkadasliks", "Uyeler2_ID", "dbo.Uyelers");
            DropForeignKey("dbo.Paylasimlars", "Uyeler_ID", "dbo.Uyelers");
            DropForeignKey("dbo.Paylasimlars", "PaylasimTur_ID", "dbo.PaylasimTurs");
            DropIndex("dbo.UGundems", new[] { "Gundem_ID" });
            DropIndex("dbo.UGundems", new[] { "Uyeler_ID" });
            DropIndex("dbo.Paylasimlars", new[] { "Uyeler_ID" });
            DropIndex("dbo.Paylasimlars", new[] { "PaylasimTur_ID" });
            DropIndex("dbo.Arkadasliks", new[] { "Uyeler2_ID" });
            DropTable("dbo.UGundems");
            DropTable("dbo.Gundems");
            DropTable("dbo.PaylasimTurs");
            DropTable("dbo.Paylasimlars");
            DropTable("dbo.Uyelers");
            DropTable("dbo.Arkadasliks");
        }
    }
}
