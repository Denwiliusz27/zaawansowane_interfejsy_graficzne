using Microsoft.EntityFrameworkCore;
using ProductsApp.Helpers;
using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace ProductsApp.ViewModels
{
    public class BasketViewModel: BaseViewModel
    {
        // lista produktów w koszyku
        public ObservableCollection<BasketProduct> Basket { get; set; } = new ObservableCollection<BasketProduct>();
        public double ProductsValue { get; set; }
        public ICommand DeleteProductFromBasketCommand { get; set; }
        public ICommand IncreaseAmountCommand { get; set; }
        public ICommand DecreaseAmountCommand { get; set; }

        // wiązanie komend z funkcjami, zainicjowanie tabeli produktów
        public BasketViewModel()
        {
            DeleteProductFromBasketCommand = new RelayCommand(DeleteProductFromBasket);
            IncreaseAmountCommand = new RelayCommand(IncreaseAmount);
            DecreaseAmountCommand = new RelayCommand(DecreaseAmount);

            SetBasketList();
        }

        // usuwanie produktu z koszyka
        private void DeleteProductFromBasket(object product)
        {
            Basket.Remove((BasketProduct)product);
            var dbProduct = DatabaseLocator.Database.BasketProducts.FirstOrDefault(x => x.Id == ((BasketProduct)product).Id);

            if (dbProduct != null)
            {
                DatabaseLocator.Database.BasketProducts.Remove(dbProduct);
                DatabaseLocator.Database.SaveChanges();
            }

            SetBasketList();
        }

        // zwiększanie ilości danego produktu
        private void IncreaseAmount(object product)
        {
            var basketProduct = (BasketProduct)product;
            basketProduct.Amount++;
            DatabaseLocator.Database.SaveChanges();

            SetBasketList();
        }

        // zmniejszanie ilości danego produktu
        private void DecreaseAmount(object product)
        {
            var basketProduct = (BasketProduct)product;
            if (basketProduct.Amount > 1)
            {
                basketProduct.Amount--;
                DatabaseLocator.Database.SaveChanges();
            }

            SetBasketList();
        }

        // ustawienie wartości wszystkich produktów oraz zapisanie produktów z bazy w koszyku
        private void SetBasketList() {
            var tmpValue = 0.0;

            Basket.Clear();
            foreach (var temp in DatabaseLocator.Database.BasketProducts.ToList())
            {
                Basket.Add(temp);
                tmpValue += temp.Product.Value * temp.Amount;
            };

            ProductsValue = tmpValue;
            OnPropertyChanged(nameof(ProductsValue));
        }
    }
}
