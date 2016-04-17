namespace DutchHearts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201604172359 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameOfHearts",
                c => new
                    {
                        GameOfHeartsID = c.Int(nullable: false, identity: true),
                        PlayerID = c.Int(nullable: false),
                        RoundID = c.Int(nullable: false),
                        GameDate = c.DateTime(nullable: false),
                        GamePhaseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameOfHeartsID)
                .ForeignKey("dbo.GamePhases", t => t.GamePhaseID, cascadeDelete: true)
                .Index(t => t.GamePhaseID);
            
            CreateTable(
                "dbo.GamePhases",
                c => new
                    {
                        GamePhaseID = c.Int(nullable: false, identity: true),
                        Phase = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GamePhaseID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        GameOfHearts_GameOfHeartsID = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerID)
                .ForeignKey("dbo.GameOfHearts", t => t.GameOfHearts_GameOfHeartsID)
                .Index(t => t.GameOfHearts_GameOfHeartsID);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        RoundID = c.Int(nullable: false, identity: true),
                        SequenceNumber = c.Int(nullable: false),
                        ScoreID = c.Int(nullable: false),
                        GamePhaseID = c.Int(nullable: false),
                        GameOfHearts_GameOfHeartsID = c.Int(),
                    })
                .PrimaryKey(t => t.RoundID)
                .ForeignKey("dbo.GamePhases", t => t.GamePhaseID, cascadeDelete: true)
                .ForeignKey("dbo.GameOfHearts", t => t.GameOfHearts_GameOfHeartsID)
                .Index(t => t.GamePhaseID)
                .Index(t => t.GameOfHearts_GameOfHeartsID);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ScoreID = c.Int(nullable: false, identity: true),
                        PlayerID = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rounds", "GameOfHearts_GameOfHeartsID", "dbo.GameOfHearts");
            DropForeignKey("dbo.Rounds", "GamePhaseID", "dbo.GamePhases");
            DropForeignKey("dbo.Players", "GameOfHearts_GameOfHeartsID", "dbo.GameOfHearts");
            DropForeignKey("dbo.GameOfHearts", "GamePhaseID", "dbo.GamePhases");
            DropIndex("dbo.Rounds", new[] { "GameOfHearts_GameOfHeartsID" });
            DropIndex("dbo.Rounds", new[] { "GamePhaseID" });
            DropIndex("dbo.Players", new[] { "GameOfHearts_GameOfHeartsID" });
            DropIndex("dbo.GameOfHearts", new[] { "GamePhaseID" });
            DropTable("dbo.Scores");
            DropTable("dbo.Rounds");
            DropTable("dbo.Players");
            DropTable("dbo.GamePhases");
            DropTable("dbo.GameOfHearts");
        }
    }
}
