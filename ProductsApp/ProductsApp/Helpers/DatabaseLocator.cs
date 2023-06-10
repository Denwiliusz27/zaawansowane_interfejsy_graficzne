using ProductsApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Helpers
{
    public class DatabaseLocator
    {
        public static ProductsDbContext Database { get; set; }
    }
}
