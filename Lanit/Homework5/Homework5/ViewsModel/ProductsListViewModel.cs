using Homework5.DAL;
using Homework5.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework5.ViewsModel
{
    public class ProductsListViewModel
    {
        public IHomeRepository HomeRepository { get; set; }
        public Product Product { get; set; }
        public static int Cost { get; set; }
    }
}
