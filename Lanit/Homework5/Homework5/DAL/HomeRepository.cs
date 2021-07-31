using Homework5.Data;
using Homework5.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Homework5.DAL
{
    public class HomeRepository : IHomeRepository
    {
        private readonly MyDbContext myDbContext;

        public HomeRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public List<ProductInBasket> ProductInBasket { get; set; }

        public void AddToBasketTable(int userId, int productId)
        {
            var product = myDbContext.ProductsInBasket
                    .Where(b => b.ProductId == productId).FirstOrDefault();

            if (product == null)
            {
                myDbContext.ProductsInBasket.Add(new ProductInBasket
                {
                    UserId = userId,
                    ProductId = productId,
                    Count = 1
                });
            }
            else
            {
                product.Count = product.Count + 1;
            }
         
            myDbContext.SaveChanges();
        }

        public void DeleteFromBasketTable(int userId, int productId)
        {
            var productInBasket = myDbContext.ProductsInBasket.
                Where(b => b.ProductId == productId).FirstOrDefault(); ;

            if (productInBasket != null)
            {
                myDbContext.ProductsInBasket.Remove(productInBasket);
                myDbContext.SaveChangesAsync();
            }
        }

        public List<ProductInBasket> GetProductsInBasketModel()
        {
            return myDbContext.ProductsInBasket.ToList();
        }

        public List<Order> OrdersModel { get; set; }

        public void AddToOrderTable(int userId)
        {
            myDbContext.Orders.RemoveRange(myDbContext.Orders);

            foreach (var x in GetProductsInBasketModel())
            {
                if (x.UserId == userId)
                {
                    myDbContext.Orders.Add(new Order
                    {
                        UserId = userId,
                        ProductId = x.ProductId,
                        Count = x.Count
                    });
                }
            }

            myDbContext.ProductsInBasket.RemoveRange(myDbContext.ProductsInBasket);
            myDbContext.SaveChanges();
        }

        public List<Order> GetOrdersModel()
        {
            return myDbContext.Orders.ToList();
        }

        public List<Product> ProductsModel { get; set; }

        public List<Product> GetProductsModel()
        {
            return myDbContext.Products.ToList();
        }

        public Product GetItemOfProducts(int Id)
        {
            return myDbContext.Products.Find(Id);
        }

        public string GetNameById(int Id)
        {
            var product = myDbContext.Products.Find(Id);
            return product.Name;
        }

        public int GetPriceById(int Id)
        {
            var product = myDbContext.Products.Find(Id);
            return product.Cost;
        }

        public int FindBook(string name)
        {
            var product = myDbContext.Products
                    .Where(b => b.Name.Equals(name)).FirstOrDefault();

            if (product != null)
            {
                return product.Id;
            }
            else
            {
                return -1;
            }
        }
    }
}
