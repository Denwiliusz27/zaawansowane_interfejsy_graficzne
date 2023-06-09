using ProductsApp.Helpers;
using ProductsApp.Views;
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

namespace ProductsApp.ViewModels
{
    public class HomeViewModel : Window
    {
        public ICommand ProductsNavigateCommand { get; set; }
        public ICommand BasketNavigateCommand { get; set; }

        public Frame MainFrame { get; set; }

        public HomeViewModel(Frame mainFrame)
        {
            MainFrame = mainFrame;
            ProductsNavigateCommand = new RelayCommand(ProductsNavigate);
            BasketNavigateCommand = new RelayCommand(BasketNavigate);
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
