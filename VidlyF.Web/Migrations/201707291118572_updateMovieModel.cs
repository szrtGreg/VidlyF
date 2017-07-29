namespace VidlyF.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovieModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
        }
    }
}
