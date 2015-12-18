namespace Komsky.Data.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCustomerForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Products", name: "Customer_Id", newName: "CustomerId");
            AlterColumn("dbo.Products", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CustomerId");
            AddForeignKey("dbo.Products", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "CustomerId" });
            AlterColumn("dbo.Products", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Products", "Customer_Id");
            AddForeignKey("dbo.Products", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
