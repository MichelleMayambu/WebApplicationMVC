namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenrerelationshipToMOvies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movie", "GenreTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movie", "GenreType_Id", c => c.Int());
            AlterColumn("dbo.Movie", "Name", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.Movie", "GenreType_Id");
            AddForeignKey("dbo.Movie", "GenreType_Id", "dbo.GenreType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "GenreType_Id", "dbo.GenreType");
            DropIndex("dbo.Movie", new[] { "GenreType_Id" });
            AlterColumn("dbo.Movie", "Name", c => c.String());
            DropColumn("dbo.Movie", "GenreType_Id");
            DropColumn("dbo.Movie", "GenreTypeId");
            DropTable("dbo.GenreType");
        }
    }
}
