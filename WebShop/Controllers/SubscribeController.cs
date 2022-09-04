using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class SubscribeController : Controller
    {
        public IActionResult Index()
        {
            return PartialView();
        }
    }
}
