using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.ViewModels
{
    internal class ProductsViewModel
    {
        public List<ProductModel> availableProducts { get; set; } = new List<ProductModel>();
        public string NewProductName {get;set;}
        public Double NewProductValue { get; set; }

        private void AddNewProduct() {
            availableProducts.Add(new ProductModel { Name = NewProductName, Value = NewProductValue });
        }
    }
}
