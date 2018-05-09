namespace EntityFun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInterestRatePeriod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "InterestRatePeriod", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "InterestRatePeriod");
        }
    }
}
