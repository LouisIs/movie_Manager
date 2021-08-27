namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNameIndatabase : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes Set Name = 'Pay as you GO' where Id = 1");
            Sql("UPDATE MembershipTypes Set Name = 'Monthly' where Id = 2");
            Sql("UPDATE MembershipTypes Set Name = 'Quarterly' where Id = 3");
            Sql("UPDATE MembershipTypes Set Name = 'Annual' where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
