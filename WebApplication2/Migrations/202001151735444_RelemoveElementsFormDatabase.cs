namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelemoveElementsFormDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Movie WHERE Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
