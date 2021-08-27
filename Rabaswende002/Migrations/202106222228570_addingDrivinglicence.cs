namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDrivinglicence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicence", c => c.String(nullable: false, maxLength: 225));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicence");
        }
    }
}
