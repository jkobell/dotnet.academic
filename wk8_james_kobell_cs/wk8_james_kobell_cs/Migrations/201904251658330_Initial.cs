namespace wk8_james_kobell_cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "CustId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "CustId", c => c.Int(nullable: false));
        }
    }
}
