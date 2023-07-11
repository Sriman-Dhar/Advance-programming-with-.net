namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.EF.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.EF.HungerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.EF.HungerDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            // Generate sample data for Restaurants
            /*for (int i = 1; i <= 10; i++)
            {
                context.Restaurants.AddOrUpdate(
                    new Restaurant()
                    {
                        Name = "Restaurant " + i,
                        Address = "Address " + i,
                        Phone = "Phone " + i
                    }
                );
            }
            
            // Generate sample data for Employees
            for (int i = 1; i <= 5; i++)
            {
                context.Employees.AddOrUpdate(
                    new Employee()
                    {
                        Name = "Employee " + i,
                        Position = "Position " + i,
                        Salary = i * 1000
                    }
                );
            }
            
            // Generate sample data for CollectRequests
            for (int i = 1; i <= 10; i++)
            {
                context.CollectRequests.AddOrUpdate(
                    new CollectRequest()
                    {
                        RequestDate = DateTime.Now.AddDays(i),
                        ExpirationDate = DateTime.Now.AddDays(i + 3),
                        RestaurantId = i,
                        EmployeeId = i % 5 + 1
                    }
                );
            }
            
            // Generate sample data for FoodDistributions
            for (int i = 1; i <= 10; i++)
            {
                context.FoodDistributions.AddOrUpdate(
                    new FoodDistribution()
                    {
                        DistributionDate = DateTime.Now.AddDays(i),
                        Quantity = i * 2,
                        CollectRequestId = i,
                        RestaurantId = i
                    }
                );
            }*/
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
