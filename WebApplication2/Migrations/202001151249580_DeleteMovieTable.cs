namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMovieTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "GenreTypeId", "dbo.GenreType");
            DropIndex("dbo.Movie", new[] { "GenreTypeId" });
            DropTable("dbo.Movie");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(),
                        NumberInStock = c.Int(nullable: false),
                        GenreTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Movie", "GenreTypeId");
            AddForeignKey("dbo.Movie", "GenreTypeId", "dbo.GenreType", "Id", cascadeDelete: true);
        }
    }
}
