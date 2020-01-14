namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieUpdatedatatype : DbMigration
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
            
            AddColumn("dbo.Movie", "GenreTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movie", "GenreTypeId");
            AddForeignKey("dbo.Movie", "GenreTypeId", "dbo.GenreType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "GenreTypeId", "dbo.GenreType");
            DropIndex("dbo.Movie", new[] { "GenreTypeId" });
            DropColumn("dbo.Movie", "GenreTypeId");
            DropTable("dbo.GenreType");
        }
    }
}
