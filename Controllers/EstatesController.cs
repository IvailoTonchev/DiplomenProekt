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
        public IActionResult Index(int id)
        {
            List<Estate> allEstates = db.Estates
                .Where(x => x.IsDeleted == false)
                .ToList();
            return View(allEstates);


            Estate EstateFd = db.Estates.Where(x => x.IsDeleted == false)
                .Include(r => r.Address).FirstOrDefault(x=>x.Id==id) ;

            return View(EstateFd);
        }
    }
}
