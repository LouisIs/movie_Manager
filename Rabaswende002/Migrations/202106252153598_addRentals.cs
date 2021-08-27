namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                    })
                .PrimaryKey(t => t.RentalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rentals");
        }
    }
}
