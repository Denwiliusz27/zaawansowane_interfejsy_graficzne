using ShoppingList.Helpers;
using ShoppingList.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShoppingList.ViewModels
{
    public class HomeViewModel : Window 
    {
        public List<string> Products { get; set; } = new List<string>();
        public string newProductName { get; set; }
        public ICommand ProductsNavigateCommand { get; set; }
        public ICommand BasketNavigateCommand { get; set; }
        public ICommand AddNewProductCommand { get; set; }
        public Frame MainFrame { get; set; }

        public HomeViewModel(Frame mainFrame)
        {
            MainFrame = mainFrame;
            ProductsNavigateCommand = new RelayCommand(ProductsNavigate);
            BasketNavigateCommand = new RelayCommand(BasketNavigate);
            AddNewProductCommand = new RelayCommand(AddNewProduct);
        }

        private void AddNewProduct()
        {
            var newProduct = newProductName;

            Products.Add(newProduct);
        }

        private void BasketNavigate()
        {
            MainFrame.Content = new BasketView();
        }

        private void ProductsNavigate()
        {
            MainFrame.Content = new ProductsView();
        }
    }
}
