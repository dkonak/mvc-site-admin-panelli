using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekSite.Entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
            Database.SetInitializer(new Datalnitializer());
        }
        public DbSet<product> Products { get; set; }
        public DbSet<Category> Categoris { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}