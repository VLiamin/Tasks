using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int NumberOfPages { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }
    }
}
