namespace wk8_james_kobell_cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add3 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Carts", "CustomerRefId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Carts", "CustomerRefId");
            AddForeignKey("dbo.Carts", "CustomerRefId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "CustomerRefId", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "CustomerRefId" });
            DropColumn("dbo.Carts", "CustomerRefId");
        }
    }
}
