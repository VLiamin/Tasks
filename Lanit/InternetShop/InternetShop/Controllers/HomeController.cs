using InternetShop.Data.Models;
using InternetShop.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly MainModel mainModel;
        private ProductsListViewModel productsListViewModel;

        public HomeController(MainModel mainModel)
        {
            this.mainModel = mainModel;
            productsListViewModel = new ProductsListViewModel();
        }

        /// <summary>
        /// The method that creates the main page 
        /// </summary>
        /// <returns>ProductsListViewModel type object</returns>
        public IActionResult GetIndex()
        {
            var items = mainModel.GetProductsModel();
            mainModel.ProductsModel = items;

            productsListViewModel.MainModel = mainModel;
            return View(productsListViewModel);
        }

        /// <summary>
        /// The method that add new product to the basket 
        /// </summary>
        /// <param name="Id"> Id of the product</param>
        /// <returns>Return to main page</returns>
        public RedirectToActionResult AddToBasket(int Id)
        {
            mainModel.AddToBasketTable(1, Id);
            return RedirectToAction("GetIndex");
        }

        /// <summary>
        /// The method that creates the information page
        /// </summary>
        /// <param name="Id">Id of the product</param>
        /// <returns>ProductsListViewModel type object</returns>
        public IActionResult GetInformation(int Id)
        {
            ProductsListViewModel.Product = mainModel.GetItemOfProducts(Id);
            return View(productsListViewModel);
        }

        /// <summary>
        /// The method that creates the basket page 
        /// </summary>
        /// <returns>ProductsListViewModel type object</returns>
        public IActionResult GetBasket()
        {
            var items = mainModel.GetProductsInBasketModel();
            mainModel.ProductInBasket = items;
            int cost = 0;

            foreach (ProductInBasket x in items)
            {
                cost += x.Count * mainModel.GetPriceById(x.ProductId);
            }

            ProductsListViewModel.Cost = cost;
            productsListViewModel.MainModel = mainModel;

            return View(productsListViewModel);
        }

        /// <summary>
        /// The method that delete product from the basket 
        /// </summary>
        /// <param name="Id">Id of the product</param>
        /// <returns>Return to basket page</returns>
        public RedirectToActionResult DeleteFromBasket(int Id)
        {
            mainModel.DeleteFromBasketTable(1, Id);
            return RedirectToAction("GetBasket");
        }

        /// <summary>
        /// The method that creates the order page
        /// </summary>
        /// <returns>ProductsListViewModel type object</returns>
        public IActionResult GetOrder()
        {
            mainModel.AddToOrderTable(1);

            var items = mainModel.GetOrdersModel();
            mainModel.OrdersModel = items;
            productsListViewModel.MainModel = mainModel;

            return View(productsListViewModel);
        }

        /// <summary>
        /// The method that find book by name 
        /// </summary>
        /// <param name="name"> name of the book</param>
        /// <returns>if mthod found book - information page else main page</returns>
        [HttpPost]
        public RedirectToActionResult FindBook(string name)
        {
            int Id = mainModel.FindBook(name);

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
