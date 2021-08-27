namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsrs : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a7accacc-6c46-4339-b352-ce29e9fd88c9', N'louisis@gmail.com', 0, N'AD0JGrdYRtPjisoUFc3Ud5WAGzjNHS0gkpLAAoYjtzFZJemHmQA/LlY6G9WON70N/A==', N'0c7c4a12-6e5a-44b3-8b0f-bcb9dc623a33', NULL, 0, 0, NULL, 1, 0, N'louisis@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ae2328e2-f059-4e78-8f88-e43ff9e9fe26', N'louisis1@gmail.com', 0, N'AMFFf6C5kikDbNgvWZW5hHeKkUTKjzQVMk2uIFnut7ZF+rzwPuzvOFoYRwO6WXbRpg==', N'78dbb7bf-9bbc-45ba-a452-d65c1476d9f0', NULL, 0, 0, NULL, 1, 0, N'louisis1@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'962c237b-87ab-41ab-bb44-0e56fb41033a', N'canManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ae2328e2-f059-4e78-8f88-e43ff9e9fe26', N'962c237b-87ab-41ab-bb44-0e56fb41033a')

");
        }
        
        public override void Down()
        {
          
        }
    }
}
