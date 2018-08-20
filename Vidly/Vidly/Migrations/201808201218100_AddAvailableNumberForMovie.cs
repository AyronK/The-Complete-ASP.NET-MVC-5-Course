namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableNumberForMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            Sql(@"UPDATE [dbo].[Movies] SET [NumberAvailable] = [NumberInStock] - (SELECT COUNT(*) FROM RENTALS WHERE [Movie_Id] = [dbo].[Movies].[Id])");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
