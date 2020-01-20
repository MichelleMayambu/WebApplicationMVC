namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreUpgrade : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "Name", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Name", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
