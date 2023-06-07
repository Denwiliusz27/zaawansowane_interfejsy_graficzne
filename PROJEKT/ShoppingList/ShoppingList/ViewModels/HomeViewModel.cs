using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingList.ViewModels
{
    public class HomeViewModel
    {
        public List<string> Products { get; set; } = new List<string>();


        public string newProductName { get; set; }

        private void addNewProduct() {
            var newProduct = newProductName;

            Products.Add(newProduct);
        }
    }
}
