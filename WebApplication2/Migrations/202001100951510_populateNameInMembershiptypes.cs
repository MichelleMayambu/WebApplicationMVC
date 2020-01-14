namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateNameInMembershiptypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE  MembershipType  SET Name= 'Pay as you go' WHERE Id= 1 ");
           


        }
        
        public override void Down()
        {
        }
    }
}
