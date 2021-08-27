namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
            Sql("drop table Movies");

        }
        
        public override void Down()
        {
        }
    }
}
