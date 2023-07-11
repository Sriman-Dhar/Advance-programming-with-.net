namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CollectRequests", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.CollectRequests", new[] { "Employee_EmployeeId" });
            RenameColumn(table: "dbo.CollectRequests", name: "Employee_EmployeeId", newName: "EmployeeId");
            AddColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Position", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FoodDistributions", "RestaurantId", c => c.Int(nullable: false));
            AlterColumn("dbo.CollectRequests", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.CollectRequests", "EmployeeId");
            CreateIndex("dbo.FoodDistributions", "RestaurantId");
            AddForeignKey("dbo.FoodDistributions", "RestaurantId", "dbo.Restaurants", "RestaurantId", cascadeDelete: false);
            AddForeignKey("dbo.CollectRequests", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: false);
            DropColumn("dbo.Employees", "FirstName");
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Employees", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Phone", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.CollectRequests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.FoodDistributions", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.FoodDistributions", new[] { "RestaurantId" });
            DropIndex("dbo.CollectRequests", new[] { "EmployeeId" });
            AlterColumn("dbo.CollectRequests", "EmployeeId", c => c.Int());
            DropColumn("dbo.FoodDistributions", "RestaurantId");
            DropColumn("dbo.Employees", "Salary");
            DropColumn("dbo.Employees", "Position");
            DropColumn("dbo.Employees", "Name");
            RenameColumn(table: "dbo.CollectRequests", name: "EmployeeId", newName: "Employee_EmployeeId");
            CreateIndex("dbo.CollectRequests", "Employee_EmployeeId");
            AddForeignKey("dbo.CollectRequests", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
