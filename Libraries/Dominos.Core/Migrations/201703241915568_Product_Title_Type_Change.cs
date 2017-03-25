namespace Dominos.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_Title_Type_Change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Title", c => c.Int(nullable: false));
        }
    }
}
