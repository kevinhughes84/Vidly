namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenreTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Genres", newName: "GenreTypes");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "GenreTypeId");
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId", newName: "IX_GenreTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenreTypeId", newName: "IX_GenreId");
            RenameColumn(table: "dbo.Movies", name: "GenreTypeId", newName: "GenreId");
            RenameTable(name: "dbo.GenreTypes", newName: "Genres");
        }
    }
}
