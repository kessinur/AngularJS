namespace AngularASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingClub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ClubId);
            
            AddColumn("dbo.Players", "Clubs_ClubId", c => c.Int());
            AlterColumn("dbo.Players", "Age", c => c.Int(nullable: false));
            CreateIndex("dbo.Players", "Clubs_ClubId");
            AddForeignKey("dbo.Players", "Clubs_ClubId", "dbo.Clubs", "ClubId");
            DropColumn("dbo.Players", "Club");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Club", c => c.String());
            DropForeignKey("dbo.Players", "Clubs_ClubId", "dbo.Clubs");
            DropIndex("dbo.Players", new[] { "Clubs_ClubId" });
            AlterColumn("dbo.Players", "Age", c => c.String());
            DropColumn("dbo.Players", "Clubs_ClubId");
            DropTable("dbo.Clubs");
        }
    }
}
