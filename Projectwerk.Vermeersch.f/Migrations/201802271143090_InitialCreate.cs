namespace Projectwerk.Vermeersch.f.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afstands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lengte = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wedstrijds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Plaats = c.String(),
                        Datum = c.DateTime(),
                        Stayer = c.Boolean(nullable: false),
                        AfstandId = c.Int(nullable: false),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Afstands", t => t.AfstandId, cascadeDelete: true)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .Index(t => t.AfstandId)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.Putters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Voornaam = c.String(),
                        Geboortedatum = c.DateTime(),
                        Gebruikersnaam = c.String(),
                        Woonplaats = c.String(),
                        Paswoord = c.String(),
                        Email = c.String(),
                        Licentie = c.Boolean(nullable: false),
                        RoleID = c.Int(nullable: false),
                        SexID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Sexes", t => t.SexID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.SexID);
            
            CreateTable(
                "dbo.Resultaats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UitslagCategorie = c.Int(nullable: false),
                        UitslagAlgemeen = c.Int(nullable: false),
                        PutterID = c.Int(nullable: false),
                        WedstrijdId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Putters", t => t.PutterID, cascadeDelete: true)
                .ForeignKey("dbo.Wedstrijds", t => t.WedstrijdId, cascadeDelete: true)
                .Index(t => t.PutterID)
                .Index(t => t.WedstrijdId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rolenaam = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Geslacht = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        soortSport = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PutterWedstrijds",
                c => new
                    {
                        Putter_Id = c.Int(nullable: false),
                        Wedstrijd_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Putter_Id, t.Wedstrijd_Id })
                .ForeignKey("dbo.Putters", t => t.Putter_Id, cascadeDelete: true)
                .ForeignKey("dbo.Wedstrijds", t => t.Wedstrijd_Id, cascadeDelete: true)
                .Index(t => t.Putter_Id)
                .Index(t => t.Wedstrijd_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wedstrijds", "SportId", "dbo.Sports");
            DropForeignKey("dbo.PutterWedstrijds", "Wedstrijd_Id", "dbo.Wedstrijds");
            DropForeignKey("dbo.PutterWedstrijds", "Putter_Id", "dbo.Putters");
            DropForeignKey("dbo.Putters", "SexID", "dbo.Sexes");
            DropForeignKey("dbo.Putters", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Resultaats", "WedstrijdId", "dbo.Wedstrijds");
            DropForeignKey("dbo.Resultaats", "PutterID", "dbo.Putters");
            DropForeignKey("dbo.Wedstrijds", "AfstandId", "dbo.Afstands");
            DropIndex("dbo.PutterWedstrijds", new[] { "Wedstrijd_Id" });
            DropIndex("dbo.PutterWedstrijds", new[] { "Putter_Id" });
            DropIndex("dbo.Resultaats", new[] { "WedstrijdId" });
            DropIndex("dbo.Resultaats", new[] { "PutterID" });
            DropIndex("dbo.Putters", new[] { "SexID" });
            DropIndex("dbo.Putters", new[] { "RoleID" });
            DropIndex("dbo.Wedstrijds", new[] { "SportId" });
            DropIndex("dbo.Wedstrijds", new[] { "AfstandId" });
            DropTable("dbo.PutterWedstrijds");
            DropTable("dbo.Sports");
            DropTable("dbo.Sexes");
            DropTable("dbo.Roles");
            DropTable("dbo.Resultaats");
            DropTable("dbo.Putters");
            DropTable("dbo.Wedstrijds");
            DropTable("dbo.Afstands");
        }
    }
}
