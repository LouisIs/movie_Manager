namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overidedate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers ( Name , IsSubscribToNewsLetter, MembershipTypeId, Birthdate) VALUES( 'Tony', 'true' , 1, 1996-08-16)");
        }
        
        public override void Down()
        {
        }
    }
}
