using Microsoft.EntityFrameworkCore;
using ProductsApp.Helpers;
using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductsApp.ViewModels
{
    public class BasketViewModel
    {
        public ObservableCollection<BasketProduct> Basket { get; set; } = new ObservableCollection<BasketProduct>();
        public ICommand DeleteProductFromBasketCommand { get; set; }
        public ICommand IncreaseAmountCommand { get; set; }
        public ICommand DecreaseAmountCommand { get; set; }

        public BasketViewModel()
        {
            DeleteProductFromBasketCommand = new RelayCommand(DeleteProductFromBasket);
            IncreaseAmountCommand = new RelayCommand(IncreaseAmount);
            DecreaseAmountCommand = new RelayCommand(DecreaseAmount);

            // pobieranie  
            foreach (var product in DatabaseLocator.Database.BasketProducts.ToList())
            {
                Basket.Add(product);
            };
        }


        private void DeleteProductFromBasket(object product)
        {
            Basket.Remove((BasketProduct)product);
            var dbProduct = DatabaseLocator.Database.BasketProducts.FirstOrDefault(x => x.Id == ((BasketProduct)product).Id);

            if (dbProduct != null)
            {
                DatabaseLocator.Database.BasketProducts.Remove(dbProduct);
                DatabaseLocator.Database.SaveChanges();
            }
        }

        private void IncreaseAmount(object product)
        {
            var basketProduct = (BasketProduct)product;
            basketProduct.Amount++;
            DatabaseLocator.Database.SaveChanges();

            Basket.Clear();
            foreach (var temp in DatabaseLocator.Database.BasketProducts.ToList())
            {
                Basket.Add(temp);
            };
        }

        private void DecreaseAmount(object product)
        {
            var basketProduct = (BasketProduct)product;
            if (basketProduct.Amount > 1)
            {
                basketProduct.Amount--;
                DatabaseLocator.Database.SaveChanges();
            }

            Basket.Clear();
            foreach (var temp in DatabaseLocator.Database.BasketProducts.ToList())
            {
                Basket.Add(temp);
            };
        }
    }
}
