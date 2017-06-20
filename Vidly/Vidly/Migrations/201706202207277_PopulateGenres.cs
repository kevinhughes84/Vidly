namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy'),('Action'),('Family'),('Romance'),('Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
