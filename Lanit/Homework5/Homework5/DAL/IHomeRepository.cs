using Homework5.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework5.DAL
{
    public interface IHomeRepository
    {
        List<ProductInBasket> ProductInBasket { get; set; }
        void AddToBasketTable(int userId, int productId);
        void DeleteFromBasketTable(int userId, int productId);
        List<ProductInBasket> GetProductsInBasketModel();
        List<Order> OrdersModel { get; set; }
        void AddToOrderTable(int userId);
        List<Order> GetOrdersModel();
        List<Product> ProductsModel { get; set; }
        List<Product> GetProductsModel();
        Product GetItemOfProducts(int Id);
        string GetNameById(int Id);
        int GetPriceById(int Id);
        int FindBook(string name);
    }
}
