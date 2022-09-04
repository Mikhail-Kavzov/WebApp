using WebShop.Models;

namespace WebShop.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<IEnumerable<Product>> FindAllByCategory(CategoryType categoryType);
    }
}
