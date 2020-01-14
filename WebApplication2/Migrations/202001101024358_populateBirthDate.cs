namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customer SET BirthDate='04/08/1994' WHERE id=1");
        }
        
        public override void Down()
        {
        }
    }
}
