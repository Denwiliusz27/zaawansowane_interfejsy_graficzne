using ShoppingList.Helpers;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingList.ViewModels
{
    internal class ProductsViewModel
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
        }
    }
}
