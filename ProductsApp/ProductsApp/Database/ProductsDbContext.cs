using Microsoft.EntityFrameworkCore;
using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductModel>()
               .HasOne(e => e.BasketProduct)
               .WithOne(e => e.Product)
               .HasForeignKey<BasketProduct>(e => e.ProductId);

            modelBuilder.Entity<BasketProduct>()
                .HasOne(e => e.Product)
                .WithOne(e => e.BasketProduct)
                .HasForeignKey<BasketProduct>(e => e.ProductId);

            modelBuilder.Entity<ProductModel>()
                .HasData( 
                    new ProductModel { Id = 1, Name="Jabłka", Value=15.6 }
                );

            modelBuilder.Entity<BasketProduct>()
                .HasData(
                    new BasketProduct { Id = 1, Amount = 1, ProductId = 1 }
                );
        }
    }
 }
