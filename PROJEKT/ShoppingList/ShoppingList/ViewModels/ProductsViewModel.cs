using Prism.Commands;
using ShoppingList.Helpers;
using ShoppingList.Models;
using ShoppingList.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShoppingList.ViewModels
{
    public class ProductsViewModel: BaseViewModel
    {
               // kolekcja której zmiany można podglądnąć
        public ObservableCollection<ProductModel> AvailableProducts { get; set; } = new ObservableCollection<ProductModel>();
        public string NewProductName {get;set;}
        public Double NewProductValue { get; set; }
        public ICommand AddNewProductCommand { get; set; }

        public ProductsViewModel() {
            AddNewProductCommand = new RelayCommand(AddNewProduct);
        }

        private void AddNewProduct()
        {
            AvailableProducts.Add(new ProductModel { Name = NewProductName, Value = NewProductValue });
            NewProductName = "";
            NewProductValue = 0;
        }

        private void DeleteProduct() { 
            
        }
    }
}
