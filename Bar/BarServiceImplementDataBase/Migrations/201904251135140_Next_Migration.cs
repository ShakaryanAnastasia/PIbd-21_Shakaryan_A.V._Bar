namespace BarServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Next_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(),
                        FromMailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                        HabitueId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Habitues", t => t.HabitueId)
                .Index(t => t.HabitueId);
            
            AddColumn("dbo.Habitues", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageInfoes", "HabitueId", "dbo.Habitues");
            DropIndex("dbo.MessageInfoes", new[] { "HabitueId" });
            DropColumn("dbo.Habitues", "Mail");
            DropTable("dbo.MessageInfoes");
        }
    }
}
