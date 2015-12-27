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
                        ProductId = c.Int(),
                        AgentReply = c.String(),
                        OwnerId = c.String(maxLength: 128),
                        AssignedAgentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AssignedAgentId)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.OwnerId)
                .Index(t => t.AssignedAgentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Tickets", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "AssignedAgentId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "AssignedAgentId" });
            DropIndex("dbo.Tickets", new[] { "OwnerId" });
            DropIndex("dbo.Tickets", new[] { "ProductId" });
            DropTable("dbo.Tickets");
        }
    }
}
