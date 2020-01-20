namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMovietableDEleteAddWithoutVAlidation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ReleaseDate = c.DateTime(),
                        DateAdded = c.DateTime(),
                        NumberInStock = c.Int(nullable: false),
                        GenreTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenreType", t => t.GenreTypeId, cascadeDelete: true)
                .Index(t => t.GenreTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "GenreTypeId", "dbo.GenreType");
            DropIndex("dbo.Movie", new[] { "GenreTypeId" });
            DropTable("dbo.Movie");
        }
    }
}
