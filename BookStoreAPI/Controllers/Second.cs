using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    public class Second : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}