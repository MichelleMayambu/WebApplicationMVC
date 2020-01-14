namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatatypeofBirthdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "BirthDate", c => c.String());
        }
    }
}
