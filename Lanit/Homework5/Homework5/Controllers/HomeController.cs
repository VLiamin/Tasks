using Homework5.DAL;
using Homework5.Data.Models;
using Homework5.Mappers;
using Homework5.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace Homework5.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class HomeController : Controller
    {
        private IHomeRepository homeRepository;
        private ProductsListViewModel productsListViewModel;
        private ProductsListViewModelMapper productsListViewModelMapper;

        public HomeController(IHomeRepository homeRepository)
        {
            this.homeRepository = homeRepository;
            productsListViewModel = new ProductsListViewModel();
            productsListViewModelMapper = new ProductsListViewModelMapper();
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            var items = homeRepository.GetProductsModel();
            homeRepository.ProductsModel = items;
            productsListViewModelMapper.Transform(productsListViewModel, homeRepository);

            return View(productsListViewModelMapper);
        }

        [HttpGet("addToBasket")]
        public RedirectToActionResult AddToBasket(int Id)
        {
            homeRepository.AddToBasketTable(1, Id);
            return RedirectToAction("GetIndex");
        }

        [HttpGet("information")]
        public IActionResult GetInformation(int Id)
        {
            productsListViewModel.Product = homeRepository.GetItemOfProducts(Id);
            return View(productsListViewModel);
        }

        [HttpGet("basket")]
        public IActionResult Basket()
        {
            var items = homeRepository.GetProductsInBasketModel();
            homeRepository.ProductInBasket = items;
            int cost = 0;

            foreach (ProductInBasket x in items)
            {
                cost += x.Count * homeRepository.GetPriceById(x.ProductId);
            }

            productsListViewModelMapper.Transform(cost);
            return View(productsListViewModelMapper.Transform(productsListViewModel, homeRepository));
        }

        [HttpGet("deleteFromBasket")]
        public RedirectToActionResult DeleteFromBasket(int Id)
        {
            homeRepository.DeleteFromBasketTable(1, Id);
            return RedirectToAction("GetBasket");
        }

        [HttpGet("order")]
        public IActionResult Order()
        {
            homeRepository.AddToOrderTable(1);

            var items = homeRepository.GetOrdersModel();
            homeRepository.OrdersModel = items;

            return View(productsListViewModelMapper.Transform(productsListViewModel, homeRepository));
        }

        [HttpGet("book")]
        public RedirectToActionResult FindBook(string name)
        {
            int Id = homeRepository.FindBook(name);

            if (Id > 0)
            {
                return RedirectToAction("GetInformation", new { Id = Id });
            }
            else
            {
                return RedirectToAction("GetIndex");
            }
        }
    }
}
