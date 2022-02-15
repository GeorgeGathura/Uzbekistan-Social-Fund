using Microsoft.AspNetCore.Mvc;

namespace Uzbekistan_Social_Fund.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
