using Microsoft.AspNetCore.Mvc;

namespace DiplomenProekt.Controllers
{
    public class EstateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
