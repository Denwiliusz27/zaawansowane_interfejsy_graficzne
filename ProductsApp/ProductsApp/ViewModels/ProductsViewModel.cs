﻿using ProductsApp.Database;
using ProductsApp.Helpers;
using ProductsApp.Models;
using ProductsApp.ViewModels;
using ProductsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProductsApp.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        // kolekcja której zmiany można podglądnąć
        public ObservableCollection<ProductModel> AvailableProducts { get; set; } = new ObservableCollection<ProductModel>();
        public string NewProductName { get; set; }
        public Double NewProductValue { get; set; }
        public ICommand AddNewProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }

        public ProductsViewModel()
        {
            AddNewProductCommand = new RelayCommand(AddNewProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);

            // pobieranie  
            foreach (var product in DatabaseLocator.Database.Products.ToList()) {
                AvailableProducts.Add(product);
            };
        }

        private void AddNewProduct()
        {
            AvailableProducts.Add(new ProductModel { Name = NewProductName, Value = NewProductValue });
            DatabaseLocator.Database.Add(new ProductModel { Name = NewProductName, Value = NewProductValue });
            DatabaseLocator.Database.SaveChanges();
            NewProductName = "";
            NewProductValue = 0;
        }

        private void DeleteProduct(object product)
        {
            AvailableProducts.Remove((ProductModel)product);
            var dbProduct = DatabaseLocator.Database.Products.FirstOrDefault( x => x.Id == ((ProductModel)product).Id );

            if (dbProduct != null )
            {
                DatabaseLocator.Database.Products.Remove(dbProduct);
                DatabaseLocator.Database.SaveChanges();
            }
        }
    }
}