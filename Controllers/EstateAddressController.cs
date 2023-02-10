using DiplomenProekt.Data;
using DiplomenProekt.Data.Models;
using DiplomenProekt.Models;
using Microsoft.AspNetCore.Mvc;
using Town = DiplomenProekt.Data.Models.Town;

namespace DiplomenProekt.Controllers
{
    public class EstateAddressController : Controller
    {
        private readonly ApplicationDbContext db;

        public EstateAddressController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var address = db.Addresses.Select(x => new InputEstateAddressModel
            {
                Id = x.Id,
                City = (Models.Town)x.City,
                Description = x.Description,
                Neighbourhood = x.Neighbourhood,
                Pics = x.Pics,
                IsDeleted=x.IsDeleted,
                Estates = x.Estates,
            }).ToList();

            return View(address);       
        }
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Create(InputEstateAddressModel model)
        {
            var address = new Address { Id = model.Id,
                City= (Town)model.City,
                Description= model.Description,
                Neighbourhood= model.Neighbourhood,
                Pics= model.Pics,
                IsDeleted = model.IsDeleted,
                Estates=model.Estates,
            };
            db.Addresses.Add(address);
            db.SaveChanges();

            return this.Redirect("Index");
        }
    }
}
