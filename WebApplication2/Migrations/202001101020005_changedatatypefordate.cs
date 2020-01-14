namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatatypefordate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "BirthDate", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
         
        }
    }
}
