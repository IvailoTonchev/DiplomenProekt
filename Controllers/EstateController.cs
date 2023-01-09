using DiplomenProekt.Data;
using DiplomenProekt.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiplomenProekt.Controllers
{
    public class EstateController : Controller
    {
        private readonly ApplicationDbContext db;

        public EstateController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Estate> allEstates = db.Estates
                .Include(r => r.EstateType)
                .Where(x => x.IsDeleted == false)
                //.ThenInclude(p=>p.Reservations)
                .ToList();
            return View(allEstates);
        }
    }
}
