using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IntroAPI.EF.Models;


namespace IntroAPI.EF
{
    public class NewsContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
    }
}