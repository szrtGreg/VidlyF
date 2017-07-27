namespace VidlyF.Web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT Genres (Id, Name) VALUES (1,'Comedy')");
            Sql("INSERT Genres (Id, Name) VALUES (2,'Horror')");
            Sql("INSERT Genres (Id, Name) VALUES (3,'Drama')");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3)");
        }
    }
}
