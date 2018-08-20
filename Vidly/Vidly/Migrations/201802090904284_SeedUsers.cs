namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'02eea52a-96c6-4442-aff9-6bb02cfd1ea4', N'admin@vidly.com', 0, N'AAot/iu01PAYPYlNNWv/7/OBE+hTVP+g0QbiLBJbaf4zaYp84F56qtiVGaz49Cr9wQ==', N'48fe6cf6-ae5f-4643-83c7-1ca1fb973457', '000000000', 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'15c941d8-ffa6-44f3-821c-c9d340b649fc', N'guest@vidly.com', 0, N'AL1mJD492jgstBTJz+q67rrFqG4gIbLfC/SK+ADcVY7hXpqdeuHA90Ye/G73PXt92w==', N'5a1d36bf-8b2c-4c5c-8b99-275bb6498046', '000000000', 0, 0, NULL, 1, 0, N'guest@vidly.com')
");

            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'49183c46-9cde-42c5-9eab-4142b509f22e', N'CanManageMovies')
");

            Sql(@"
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02eea52a-96c6-4442-aff9-6bb02cfd1ea4', N'49183c46-9cde-42c5-9eab-4142b509f22e')
");
        }

        public override void Down()
        {
        }
    }
}
