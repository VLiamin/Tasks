using Homework5.Controllers;
using Homework5.DAL;
using Homework5.Data;
using Homework5.Data.Models;
using Homework5.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework5Tests
{
    class HomeRepositoryTests
    {
        [Test]
        public void DeleteFromBasketTableTest()
        {
            var mock = new Mock<MyDbContext>();
            mock.Setup(x => x.SaveChanges());
            var repository = new HomeRepository(mock.Object);

            Assert.Throws<NullReferenceException>(() => repository.DeleteFromBasketTable(1, 2));
        }

        [Test]
        public void AddToOrderTableTest()
        {
            var mock = new Mock<MyDbContext>();
            mock.Setup(x => x.SaveChanges());
            var repository = new HomeRepository(mock.Object);

            Assert.Throws<InvalidOperationException>(() => repository.AddToOrderTable(1));
        }
    }
}
