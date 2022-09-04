
namespace WebShop.Repositories
{
    using WebShop.Models;

    public interface IFileRepository:IRepository<FileDB>
    {
        Task<FileDB?> GetPath(string path);
    }
}
