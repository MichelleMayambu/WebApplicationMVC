namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populategenretypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreType (GenreName) VALUES('ACTION')");
            Sql("INSERT INTO GenreType (GenreName) VALUES('DRAMA')");
            Sql("INSERT INTO GenreType (GenreName) VALUES('SCIFI')");
            Sql("INSERT INTO GenreType (GenreName) VALUES('DOCUMENTARY')");
            Sql("INSERT INTO GenreType (GenreName) VALUES('AVENTURE')");




        }

        public override void Down()
        {
        }
    }
}
