using DiplomenProekt.Data;
using DiplomenProekt.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiplomenProekt.Controllers
{
    public class EstatesController : Controller
    {
        private readonly ApplicationDbContext db;

        public EstatesController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Estate> allEstates = db.Estates
                .Where(x => x.IsDeleted == false)
                .ToList();
            return View(allEstates);


        }


        public IActionResult Details(int id)
        {
            Estate estateFd = db.Estates
           .Where(x => x.IsDeleted == false)
           .Include(e=>e.Address)
           .Include(e => e.Extras)
           .FirstOrDefault(x=>x.Id==id);
           
            return View(estateFd);
        }
    }
}
