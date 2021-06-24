using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationTEST.Orders;

namespace WebApplicationTEST

{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Datum> Datums { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=remskladapi;Trusted_Connection=True;");
              optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=greatsteve");

        }
    }
}
