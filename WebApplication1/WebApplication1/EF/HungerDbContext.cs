using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.EF.Models;

namespace WebApplication1.EF
{
    public class HungerDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<FoodDistribution> FoodDistributions { get; set; }
    }
}