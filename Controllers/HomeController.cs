using DiplomenProekt.Models;
using DiplomenProekt.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiplomenProekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataBaseSeeder dbs;        
        
        public HomeController(ILogger<HomeController> logger,IDataBaseSeeder dbs)
        {
            _logger = logger; 
            this.dbs = dbs;
        }

        public IActionResult Index()
        {
            return View();
        }

        public  async Task <IActionResult> Seed()
        {
            if (await dbs.HasAnyDataInDBAsync() ==false)
            {
                await dbs.InsertDataInDBAsync();  

            }
           

            return Redirect("Index");
        }

        public IActionResult Privacy()
        {

            return View();
        }
        public IActionResult Contacts()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}