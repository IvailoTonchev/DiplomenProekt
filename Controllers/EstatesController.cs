using DiplomenProekt.Data;
using DiplomenProekt.Data.Models;
using DiplomenProekt.DTO;
using DiplomenProekt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

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
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Create(CreateEstateDTO model)
        {
            //var estate = new Estate { Id = model.Id,
            //EstateStatus= (Data.Models.EstateStatus)model.EstateStatus,
            //EstateType= (Data.Models.EstateType)model.EstateType,
            //Rooms=model.Rooms,
            //Price=model.Price,
            //Pictures=model.Pictures,
            //MaxFloor=model.MaxFloor,
            //MainPic=model.MainPic,
            //Floor=model.Floor,
            //Description=model.Description,
            //Area=model.Area,
            //AddressId=model.AddressId,
            //IsDeleted=model.IsDeleted,
            //Extras=model.Extras,
            //ExtrasId=model.ExtrasId,
            //Address=model.Address,
            //};
            //db.Estates.Add(estate);
            //db.SaveChanges();

            return this.Redirect("Index");
        }


    }
}
