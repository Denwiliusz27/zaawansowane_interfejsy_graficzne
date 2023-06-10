using Microsoft.EntityFrameworkCore;
using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Database
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Tasks.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}
