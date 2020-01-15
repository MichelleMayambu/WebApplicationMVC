namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToGenreTypeId1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "PopularityScale", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "PopularityScale");
        }
    }
}
