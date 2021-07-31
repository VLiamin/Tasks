using Homework5.Controllers;
using Homework5.DAL;
using Homework5.Data.Models;
using Homework5.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Homework5Tests
{
    public class Tests
    {
        [Test]
        public void GetInformationTest()
        {
            var mock = new Mock<IHomeRepository>();
            mock.Setup(x => x.GetItemOfProducts(1)).Returns(GetTestProduct());
            var controller = new HomeController(mock.Object);

            var result = controller.GetInformation(1);
            Assert.That(result, Is.TypeOf<ViewResult>());

            ViewResult viewResult = result as ViewResult;
            ProductsListViewModel productsListViewModel = viewResult.Model as ProductsListViewModel;
            Assert.AreEqual(GetTestProduct().Cost, productsListViewModel.Product.Cost);
        }

        [Test]
        public void IndexTest()
        {
            var mock = new Mock<IHomeRepository>();
            mock.Setup(x => x.GetProductsModel()).Returns(GetTestProducts());
            var controller = new HomeController(mock.Object);

            var result = controller.Index();
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void BasketTest()
        {
            var mock = new Mock<IHomeRepository>();
            mock.Setup(x => x.GetProductsInBasketModel()).Returns(GetTestProductsInBasket());
            var controller = new HomeController(mock.Object);

            var result = controller.Basket();
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void OrderTest()
        {
            var mock = new Mock<IHomeRepository>();
            mock.Setup(x => x.GetOrdersModel()).Returns(GetTestOrder());
            var controller = new HomeController(mock.Object);

            var result = controller.Order();
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        private List<Product> GetTestProducts()
        {

            var products = new List<Product>
            {
                new Product {Id = 1, Name = "Book", Author = "Author", NumberOfPages = 100,
                                Cost = 183, Weight = 400},
                new Product {Id = 2, Name = "Book2", Author = "Author2", NumberOfPages = 102,
                                Cost = 185, Weight = 402}
            };

            return products;
        }

        private List<ProductInBasket> GetTestProductsInBasket()
        {

            var products = new List<ProductInBasket>
            {
                new ProductInBasket {Id = 1, UserId = 1, ProductId = 1, Count = 3},
                new ProductInBasket {Id = 2, UserId = 1, ProductId = 2, Count = 3}
            };

            return products;
        }

        private Product GetTestProduct()
        {

            Product product = new Product
            {
                Id = 1,
                Name = "Book",
                Author = "Author",
                NumberOfPages = 100,
                Cost = 183,
                Weight = 400
            };

            return product;
        }
        private List<Order> GetTestOrder()
        {

            var products = new List<Order>
            {
                new Order {Id = 1, UserId = 1, ProductId = 1, Count = 3},
                new Order {Id = 2, UserId = 1, ProductId = 2, Count = 3}
            };

            return products;
        }
    }
}