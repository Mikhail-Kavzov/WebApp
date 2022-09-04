using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.Controllers
{
    [NonController]
    public class FileController : Controller
    {
        private readonly IFileRepository _fileRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController(IFileRepository fileRepository, IWebHostEnvironment webHostEnvironment)
        {
            _fileRepository = fileRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [NonAction]
        public async Task CreateFile(IEnumerable<IFormFile> loadFiles, Product? product = null, string pathToFolder = "/images/")
        {

            foreach (var file in loadFiles)
            {
                string fileName = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())) + file.FileName; //Guid for fileName
                string path = pathToFolder + fileName;

                using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create)) //create file
                {
                    await file.CopyToAsync(fileStream); //save asynchroniously
                }
                FileDB fileDB = new() //model for DB
                {
                    Name = fileName,
                    Path = path,
                    Product = product
                };
                _fileRepository.Create(fileDB);

            }
            await _fileRepository.SaveAsync();

        }
    }
}
