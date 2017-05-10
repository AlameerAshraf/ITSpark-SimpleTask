namespace ITSpark_AlameerAshraf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CId);
            
            AddColumn("dbo.Students", "CId", c => c.Guid());
            CreateIndex("dbo.Students", "CId");
            AddForeignKey("dbo.Students", "CId", "dbo.Countries", "CId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CId", "dbo.Countries");
            DropIndex("dbo.Students", new[] { "CId" });
            DropColumn("dbo.Students", "CId");
            DropTable("dbo.Countries");
        }
    }
}
