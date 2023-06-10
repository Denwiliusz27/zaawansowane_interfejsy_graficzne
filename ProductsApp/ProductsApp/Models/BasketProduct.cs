using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    public class BasketProduct
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        [ForeignKey("ProductId")]
        public ProductModel product { get; set; }
    }
}
