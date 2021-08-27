namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Rental_RentalId", c => c.Int());
            AddColumn("dbo.Rentals", "CustomerId_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Rental_RentalId");
            CreateIndex("dbo.Rentals", "CustomerId_Id");
            AddForeignKey("dbo.Rentals", "CustomerId_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "Rental_RentalId", "dbo.Rentals", "RentalId");
            DropColumn("dbo.Rentals", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movies", "Rental_RentalId", "dbo.Rentals");
            DropForeignKey("dbo.Rentals", "CustomerId_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "CustomerId_Id" });
            DropIndex("dbo.Movies", new[] { "Rental_RentalId" });
            DropColumn("dbo.Rentals", "CustomerId_Id");
            DropColumn("dbo.Movies", "Rental_RentalId");
        }
    }
}
