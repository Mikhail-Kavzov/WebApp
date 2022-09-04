using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext db;

        public ProductRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Delete(Product item)
        {
            db.Products.Remove(item);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await db.Products.Include(c=>c.FileProducts).ToListAsync();           
        }

        public async Task<Product?> GetElementAsync(int id)
        {
            return await db.Products.Include(c => c.FileProducts).FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetRangeAsync(int start, int end) 
        {
            return await db.Products.Include(c => c.FileProducts).Where(p => p.ProductId >= start && p.ProductId <= end).ToListAsync();
        }

        public void Update(Product item)
        {
            db.Products.Update(item);
        }

        public async Task SaveAsync()
        {
             await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> FindAllByCategory(CategoryType category)
        {
            return await db.Products.Include(c => c.FileProducts).Where(p => p.Category == category).ToListAsync();
        }
        
    }
}
