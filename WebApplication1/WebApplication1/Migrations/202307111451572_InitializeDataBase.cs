namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        CollectRequestId = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.CollectRequestId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.FoodDistributions",
                c => new
                    {
                        FoodDistributionId = c.Int(nullable: false, identity: true),
                        CollectRequestId = c.Int(nullable: false),
                        DistributionDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodDistributionId)
                .ForeignKey("dbo.CollectRequests", t => t.CollectRequestId, cascadeDelete: true)
                .Index(t => t.CollectRequestId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectRequests", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.FoodDistributions", "CollectRequestId", "dbo.CollectRequests");
            DropForeignKey("dbo.CollectRequests", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.FoodDistributions", new[] { "CollectRequestId" });
            DropIndex("dbo.CollectRequests", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.CollectRequests", new[] { "RestaurantId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.FoodDistributions");
            DropTable("dbo.Employees");
            DropTable("dbo.CollectRequests");
        }
    }
}
