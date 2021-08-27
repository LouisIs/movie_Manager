namespace Rabaswende002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMovieGenreInDBContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                      //  address = c.String(nullable:true),
                   //     MyProperty = c.Int(nullable: false),
                    //    Address = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        InStock = c.Byte(nullable: false),
                     //   NumbAvailable = c.Byte(nullable: false),
                        GenreId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
