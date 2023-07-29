namespace E_TicaretSitesiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(maxLength: 10, unicode: false),
                        Sifre = c.String(maxLength: 30, unicode: false),
                        Yetki = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Caris",
                c => new
                    {
                        CariID = c.Int(nullable: false, identity: true),
                        CariAd = c.String(maxLength: 30, unicode: false),
                        CariSoyad = c.String(nullable: false, maxLength: 30, unicode: false),
                        CariSehir = c.String(maxLength: 13, unicode: false),
                        CariMail = c.String(maxLength: 50, unicode: false),
                        Sifre = c.String(maxLength: 20, unicode: false),
                        Sil = c.Boolean(nullable: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CariID);
            
            CreateTable(
                "dbo.SatisHarekets",
                c => new
                    {
                        SatisID = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunID = c.Int(nullable: false),
                        CariID = c.Int(nullable: false),
                        PersonelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SatisID)
                .ForeignKey("dbo.Caris", t => t.CariID, cascadeDelete: true)
                .ForeignKey("dbo.Personels", t => t.PersonelID, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.UrunID)
                .Index(t => t.CariID)
                .Index(t => t.PersonelID);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(maxLength: 30, unicode: false),
                        PersonelSoyad = c.String(maxLength: 30, unicode: false),
                        PersonelGorsel = c.String(maxLength: 250, unicode: false),
                        DepartmanID = c.Int(nullable: false),
                        Sil = c.Boolean(nullable: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelID)
                .ForeignKey("dbo.Departmen", t => t.DepartmanID, cascadeDelete: true)
                .Index(t => t.DepartmanID);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        DepartmanID = c.Int(nullable: false, identity: true),
                        DepartmanAd = c.String(maxLength: 30, unicode: false),
                        Sil = c.Boolean(nullable: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmanID);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunID = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        Marka = c.String(maxLength: 30, unicode: false),
                        Stok = c.Short(nullable: false),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sil = c.Boolean(nullable: false),
                        Durum = c.Boolean(nullable: false),
                        UrunGorsel = c.String(maxLength: 250, unicode: false),
                        KategoriID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunID)
                .ForeignKey("dbo.Kategoris", t => t.KategoriID, cascadeDelete: true)
                .Index(t => t.KategoriID);
            
            CreateTable(
                "dbo.FaturaDetays",
                c => new
                    {
                        FaturaDetayID = c.Int(nullable: false, identity: true),
                        Miktar = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FaturaID = c.Int(nullable: false),
                        UrunID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaturaDetayID)
                .ForeignKey("dbo.Faturas", t => t.FaturaID, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.FaturaID)
                .Index(t => t.UrunID);
            
            CreateTable(
                "dbo.Faturas",
                c => new
                    {
                        FaturaID = c.Int(nullable: false, identity: true),
                        FaturaSeriNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        FaturaSiraNo = c.String(maxLength: 6, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        TeslimEden = c.String(maxLength: 30, unicode: false),
                        TeslimAlan = c.String(maxLength: 30, unicode: false),
                        Toplam = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FaturaID);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.Detays",
                c => new
                    {
                        DetayID = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        UrunBilgi = c.String(maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.DetayID);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        GiderID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GiderID);
            
            CreateTable(
                "dbo.Yapilacaks",
                c => new
                    {
                        YapilacakID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 100, unicode: false),
                        Durum = c.Boolean(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.YapilacakID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SatisHarekets", "UrunID", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "KategoriID", "dbo.Kategoris");
            DropForeignKey("dbo.FaturaDetays", "UrunID", "dbo.Uruns");
            DropForeignKey("dbo.FaturaDetays", "FaturaID", "dbo.Faturas");
            DropForeignKey("dbo.SatisHarekets", "PersonelID", "dbo.Personels");
            DropForeignKey("dbo.Personels", "DepartmanID", "dbo.Departmen");
            DropForeignKey("dbo.SatisHarekets", "CariID", "dbo.Caris");
            DropIndex("dbo.FaturaDetays", new[] { "UrunID" });
            DropIndex("dbo.FaturaDetays", new[] { "FaturaID" });
            DropIndex("dbo.Uruns", new[] { "KategoriID" });
            DropIndex("dbo.Personels", new[] { "DepartmanID" });
            DropIndex("dbo.SatisHarekets", new[] { "PersonelID" });
            DropIndex("dbo.SatisHarekets", new[] { "CariID" });
            DropIndex("dbo.SatisHarekets", new[] { "UrunID" });
            DropTable("dbo.Yapilacaks");
            DropTable("dbo.Giders");
            DropTable("dbo.Detays");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Faturas");
            DropTable("dbo.FaturaDetays");
            DropTable("dbo.Uruns");
            DropTable("dbo.Departmen");
            DropTable("dbo.Personels");
            DropTable("dbo.SatisHarekets");
            DropTable("dbo.Caris");
            DropTable("dbo.Admins");
        }
    }
}
