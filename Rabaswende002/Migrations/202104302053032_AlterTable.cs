namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Cutomers ALTER COLUMN Birthdate DATE NULL");
            
        }
        
        public override void Down()
        {
        }
    }
}
