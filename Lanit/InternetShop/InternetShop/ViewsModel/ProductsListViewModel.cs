using InternetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.ViewsModel
{
    public class ProductsListViewModel
    {
        public MainModel MainModel { get; set; }
        public static Product Product { get; set; }
        public static int Cost { get; set; }
    }
}
