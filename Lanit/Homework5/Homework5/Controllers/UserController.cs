using Homework5.DAL;
using Homework5.Data.Models;
using Homework5.Mappers;
using Homework5.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace Homework5.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        private UserViewModel userViewModel;
        private UserViewModelMapper userViewModelMapper;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            userViewModel = new UserViewModel();
            userViewModelMapper = new UserViewModelMapper();
        }

        [HttpGet("index")]
        public IActionResult Index(int Id)
        {
            User user = userRepository.GetUser(Id);
            return View(userViewModelMapper.Transform(user, userViewModel));
        }

        [HttpPost("user")]
        public RedirectToActionResult AddUser(User user)
        {
            userRepository.AddUser(user);
            return RedirectToAction("Home", "Index");
        }

        [HttpPost("name")]
        public RedirectToActionResult ChangeName(int Id, string name)
        {
            userRepository.ChangeName(Id, name);
            return RedirectToAction("Home", "Index");
        }

        [HttpGet("delete")]
        public RedirectToActionResult DeleteUser(int Id)
        {
            userRepository.DeleteUser(Id);
            return RedirectToAction("Home", "Index");
        }
    }
}
