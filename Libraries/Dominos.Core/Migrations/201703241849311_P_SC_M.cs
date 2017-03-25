namespace Dominos.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class P_SC_M : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileBinary = c.Binary(),
                        FileName = c.String(maxLength: 100),
                        FileExtension = c.String(maxLength: 10),
                        FileSize = c.Int(nullable: false),
                        FileContentType = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Media", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.ShoppingCart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCart", "UserId", "dbo.User");
            DropForeignKey("dbo.ShoppingCart", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ImageId", "dbo.Media");
            DropIndex("dbo.ShoppingCart", new[] { "ProductId" });
            DropIndex("dbo.ShoppingCart", new[] { "UserId" });
            DropIndex("dbo.Product", new[] { "ImageId" });
            DropTable("dbo.User");
            DropTable("dbo.ShoppingCart");
            DropTable("dbo.Product");
            DropTable("dbo.Media");
        }
    }
}
