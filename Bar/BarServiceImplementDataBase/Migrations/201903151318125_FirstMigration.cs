namespace BarServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HabitueId = c.Int(nullable: false),
                        CocktailId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cocktails", t => t.CocktailId, cascadeDelete: true)
                .ForeignKey("dbo.Habitues", t => t.HabitueId, cascadeDelete: true)
                .Index(t => t.HabitueId)
                .Index(t => t.CocktailId);
            
            CreateTable(
                "dbo.Cocktails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CocktailName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Habitues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HabitueFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CocktailIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CocktailId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        IngredientName = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PantryIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PantryId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Pantries", t => t.PantryId, cascadeDelete: true)
                .Index(t => t.PantryId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Pantries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PantryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PantryIngredients", "PantryId", "dbo.Pantries");
            DropForeignKey("dbo.PantryIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.CocktailIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Bookings", "HabitueId", "dbo.Habitues");
            DropForeignKey("dbo.Bookings", "CocktailId", "dbo.Cocktails");
            DropIndex("dbo.PantryIngredients", new[] { "IngredientId" });
            DropIndex("dbo.PantryIngredients", new[] { "PantryId" });
            DropIndex("dbo.CocktailIngredients", new[] { "IngredientId" });
            DropIndex("dbo.Bookings", new[] { "CocktailId" });
            DropIndex("dbo.Bookings", new[] { "HabitueId" });
            DropTable("dbo.Pantries");
            DropTable("dbo.PantryIngredients");
            DropTable("dbo.Ingredients");
            DropTable("dbo.CocktailIngredients");
            DropTable("dbo.Habitues");
            DropTable("dbo.Cocktails");
            DropTable("dbo.Bookings");
        }
    }
}
