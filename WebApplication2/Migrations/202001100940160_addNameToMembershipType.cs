namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipType", "Name", c => c.String(nullable: false, maxLength: 255));
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipType", "Name");
        }
    }
}
