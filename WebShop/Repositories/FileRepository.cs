using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Repositories
{

    public class FileRepository : IFileRepository
    {
        private readonly ApplicationContext db;

        public FileRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(FileDB item)
        {
            db.Files.Add(item);
        }

        public void Delete(FileDB item)
        {
            db.Files.Remove(item);
        }

        public async Task<IEnumerable<FileDB>> GetAllAsync()
        {
            return await db.Files.Include(p=>p.Product).ToListAsync();
        }

        public async Task<FileDB?> GetElementAsync(int id)
        {
            return await db.Files.Include(p => p.Product).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<FileDB>> GetRangeAsync(int start, int end)
        {
            return await db.Files.Include(p => p.Product).Where(p => p.Id >= start && p.Id <= end).ToListAsync();
        }

        public void Update(FileDB item)
        {
            db.Files.Update(item);
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public async Task<FileDB?> GetPath(string path)
        {
            return await db.Files.FirstOrDefaultAsync(x => x.Path == path);
        }
    }
}
