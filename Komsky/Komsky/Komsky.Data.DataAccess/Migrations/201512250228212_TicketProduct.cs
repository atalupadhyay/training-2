namespace Komsky.Data.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "ProductId", "dbo.Products");
            DropIndex("dbo.Tickets", new[] { "ProductId" });
            AlterColumn("dbo.Tickets", "ProductId", c => c.Int());
            CreateIndex("dbo.Tickets", "ProductId");
            AddForeignKey("dbo.Tickets", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ProductId", "dbo.Products");
            DropIndex("dbo.Tickets", new[] { "ProductId" });
            AlterColumn("dbo.Tickets", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "ProductId");
            AddForeignKey("dbo.Tickets", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
