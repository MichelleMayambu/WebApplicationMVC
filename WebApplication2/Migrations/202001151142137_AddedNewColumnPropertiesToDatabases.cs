namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewColumnPropertiesToDatabases : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "ReleaseDate", c => c.DateTime());
        }
    }
}
