using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _product;

        public HomeController(IProductRepository product)
        {
            _product=product;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _product.GetRangeAsync(1, 8);
            return View(res);
        }



        [NonAction]
        public IActionResult MainTitle()
        {
            return PartialView();
        }
    }
}