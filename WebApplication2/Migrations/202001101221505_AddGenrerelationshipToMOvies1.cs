namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenrerelationshipToMOvies1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "GenreType_Id", "dbo.GenreType");
            DropIndex("dbo.Movie", new[] { "GenreType_Id" });
            DropColumn("dbo.Movie", "GenreTypeId");
            DropColumn("dbo.Movie", "GenreType_Id");
            DropTable("dbo.GenreType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenreType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movie", "GenreType_Id", c => c.Int());
            AddColumn("dbo.Movie", "GenreTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movie", "GenreType_Id");
            AddForeignKey("dbo.Movie", "GenreType_Id", "dbo.GenreType", "Id");
        }
    }
}
