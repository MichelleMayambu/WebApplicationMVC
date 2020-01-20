namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMovietable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Movie", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.Movie", "GenreTypeId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movie", "Name", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
