namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (Id, Name) Values (1 , 'Comedy')");
            Sql("insert into Genres (Id, Name) Values (2 ,'Action')");
            Sql("insert into Genres (Id, Name) Values (3 , 'Family')");
            Sql("insert into Genres (Id, Name) Values (4 ,'Romance')");
            Sql("insert into Genres (Id, Name) Values (5 , 'Drama')");
            Sql("insert into Genres (Id, Name) Values (6 , 'HardCor')");
        }
        
        public override void Down()
        {
        }
    }
}
