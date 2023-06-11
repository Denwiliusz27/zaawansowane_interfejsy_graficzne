using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    // model koszyka
    public class BasketProduct
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; } // oznaczenie relacji 1 do 1 z produktem
        public ProductModel Product { get; set; } // oznaczenie relacji 1 do 1 z produktem
    }
}
