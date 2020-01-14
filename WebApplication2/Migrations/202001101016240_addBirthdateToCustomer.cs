namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "BirthDate");
        }
    }
}
