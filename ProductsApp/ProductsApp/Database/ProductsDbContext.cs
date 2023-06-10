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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Tasks.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductModel>()
        //        .HasData(
        //            new ProductModel { Id = 1, Name = "jabłka", Value = 15.4 },
        //            new ProductModel { Id = 2, Name = "mleko", Value = 4.45 },
        //            new ProductModel { Id = 3, Name = "woda", Value = 1.99 });
        //}

    }
}
