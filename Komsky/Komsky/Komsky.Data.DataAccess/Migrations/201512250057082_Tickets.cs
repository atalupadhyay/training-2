namespace Komsky.Data.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tickets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        TicketPriority = c.Int(nullable: false),
                        TicketState = c.Int(nullable: false),
                        AgentReply = c.String(),
                        OwnerName = c.String(maxLength: 128),
                        AssignedAgentName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AssignedAgentName)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerName)
                .Index(t => t.OwnerName)
                .Index(t => t.AssignedAgentName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "OwnerName", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "AssignedAgentName", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "AssignedAgentName" });
            DropIndex("dbo.Tickets", new[] { "OwnerName" });
            DropTable("dbo.Tickets");
        }
    }
}
