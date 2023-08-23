using Homework5.DAL;
using Homework5.Data.Models;
using Homework5.ViewsModel;

namespace Homework5.Mappers
{
    public class ProductsListViewModelMapper
    {
        public ProductsListViewModel Transform(ProductsListViewModel productsListViewModel, 
            IHomeRepository homeRepository)
        {
            productsListViewModel.HomeRepository = homeRepository;
            return productsListViewModel;
        }

        public void Transform(int cost)
        {
            ProductsListViewModel.Cost = cost;
        }
    }
}
