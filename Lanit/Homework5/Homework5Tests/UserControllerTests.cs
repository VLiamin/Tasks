using Homework5.Controllers;
using Homework5.DAL;
using Homework5.Data.Models;
using Homework5.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Homework5Tests
{
    class UserControllerTests
    {
        [Test]
        public void IndexTest()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetUser(1)).Returns(GetTestUser());
            var controller = new UserController(mock.Object);

            var result = controller.Index(1);
            Assert.That(result, Is.TypeOf<ViewResult>());
            ViewResult viewResult = result as ViewResult;
            UserViewModel userViewModel = viewResult.Model as UserViewModel;
            Assert.AreEqual(GetTestUser().Name, userViewModel.User.Name);
        }

        [Test]
        public void DeleteTest()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.DeleteUser(1));
            var controller = new UserController(mock.Object);

            var result = controller.DeleteUser(1);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public void ChangeNameTest()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.ChangeName(1, "Misha"));
            var controller = new UserController(mock.Object);

            var result = controller.ChangeName(1, "Misha");
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public void AddUserTest()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetUser(1));
            var controller = new UserController(mock.Object);

            var result = controller.AddUser(GetTestUser());
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        private User GetTestUser()
        {

            User user = new User { Id = 1, Name = "Vova", Age = 21 };

            return user;
        }
    }
}
