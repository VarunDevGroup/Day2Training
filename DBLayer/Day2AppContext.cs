using Microsoft.EntityFrameworkCore;
using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBLayer
{
    public class Day2AppContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=VarunPC\SQLEXPRESS;Database=Day2DemoDB;Integrated Security=True;TrustServerCertificate=True;");

            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrice { get; set; }

    }
}
