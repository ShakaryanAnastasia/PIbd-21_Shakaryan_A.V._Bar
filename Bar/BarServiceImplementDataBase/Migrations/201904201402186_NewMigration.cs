namespace BarServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bartenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BartenderFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bookings", "BartenderId", c => c.Int());
            CreateIndex("dbo.Bookings", "BartenderId");
            AddForeignKey("dbo.Bookings", "BartenderId", "dbo.Bartenders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "BartenderId", "dbo.Bartenders");
            DropIndex("dbo.Bookings", new[] { "BartenderId" });
            DropColumn("dbo.Bookings", "BartenderId");
            DropTable("dbo.Bartenders");
        }
    }
}
