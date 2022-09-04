using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductRepository _productRepository;

        private static IEnumerable<Product>? products;

        private static readonly int pageSize = 8;

        public CategoryController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task <IActionResult> Index(CategoryType id)
        {   
           products =await _productRepository.FindAllByCategory(id);
            return View(GetItemsPage(0));
        }

       

        public IActionResult LoadProducts(int? id)
        {
            int page = id ?? 0;
            var result = GetItemsPage(page);
            if (result?.Count == 0)
                return NotFound();
            return PartialView("/Views/Product/Purchase.cshtml",result);
        }

        private List<Product>? GetItemsPage(int page)
        {
            var itemsToSkip = page * pageSize;

            return products?.Skip(itemsToSkip).Take(pageSize).ToList();
        }
    }
}
