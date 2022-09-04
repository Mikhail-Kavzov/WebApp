using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using WebShop.Models;
using WebShop.Rand;
using WebShop.Repositories;

namespace WebShop.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductRepository _product;
        private readonly IFileRepository _fileRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductRepository product, IFileRepository fileRepository, IWebHostEnvironment webHostEnvironment)
        {          
            _product = product;
            _fileRepository= fileRepository;
            _webHostEnvironment= webHostEnvironment;
        }


        // [Route("{action}/{id:int}")]

        public async Task<IActionResult> ProductInfo(int id) //Read 
        {
            var result=await _product.GetElementAsync(id);
            if (result == null)
                return NotFound();
            var arrRes=Randomizer.GenerateRange(1, 8);
            var products = (await _product.GetRangeAsync(arrRes[0], arrRes[1]-1)).ToList();
            products.Add(result);        
            return View(products);  
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Product product, IEnumerable<IFormFile> loadFiles)  //Create 
        {          
            if (ModelState.IsValid)
            {
                _product.Create(product);
                await _product.SaveAsync();
                await new FileController(_fileRepository,_webHostEnvironment).CreateFile(loadFiles, product);
                return RedirectToAction("ProductInfo", new { id = product.ProductId });               
            }
            return View();
        }

        


        [NonAction]
        public IActionResult Purchase(IEnumerable<Product> product)
        {
            return PartialView(product);
        }

        [NonAction]
        public IActionResult ProductPhotos(Product product)
        {
            return PartialView(product);
        }
    }
}
