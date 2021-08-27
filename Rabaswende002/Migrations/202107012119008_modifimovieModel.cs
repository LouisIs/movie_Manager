namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifimovieModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Rental_RentalId", "dbo.Rentals");
            DropIndex("dbo.Movies", new[] { "Rental_RentalId" });
            AddColumn("dbo.Rentals", "MovieIds_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "MovieIds_Id");
            AddForeignKey("dbo.Rentals", "MovieIds_Id", "dbo.Movies", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Rental_RentalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Rental_RentalId", c => c.Int());
            DropForeignKey("dbo.Rentals", "MovieIds_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "MovieIds_Id" });
            DropColumn("dbo.Rentals", "MovieIds_Id");
            CreateIndex("dbo.Movies", "Rental_RentalId");
            AddForeignKey("dbo.Movies", "Rental_RentalId", "dbo.Rentals", "RentalId");
        }
    }
}
