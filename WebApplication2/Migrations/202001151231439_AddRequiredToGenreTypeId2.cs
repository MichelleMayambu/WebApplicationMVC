namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToGenreTypeId2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movie", "PopularityScale");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "PopularityScale", c => c.Int(nullable: false));
        }
    }
}
