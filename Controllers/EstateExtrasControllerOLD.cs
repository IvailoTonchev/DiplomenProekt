//using DiplomenProekt.Data;
//using DiplomenProekt.Data.Models;
//using DiplomenProekt.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace DiplomenProekt.Controllers
//{
//    public class EstateExtrasController : Controller
//    {
//        private readonly ApplicationDbContext db;

//        public EstateExtrasController(ApplicationDbContext db)
//        {
//            this.db = db;
//        }
//        public IActionResult Index()
//        {
//            var extras = db.EstateExtras.Select(x => new InputEstateExtrasModel
//            {
//                Id = x.Id,
//                East=x.East,
//                Elevator=x.Elevator,
//                HasElectricity=x.HasElectricity,
//                HasGas=x.HasGas,
//                HasWater=x.HasWater,
//                North=x.North,
//                Rent=x.Rent,
//                South=x.South,
//                West=x.West,
//                IsDeleted=x.IsDeleted,
//                Estate=x.Estate,
//                EstateId=x.EstateId,
                
//            }).ToList();

//            return View(extras);
//        }
//        [HttpGet]
//        public IActionResult Create()
//        {
//            return this.View();
//        }
//        [HttpPost]
//        public IActionResult Create(InputEstateExtrasModel model)
//        {
//            var extras = new EstateExtras { Id = model.Id,
//            East=model.East,
//            Elevator = model.Elevator,
//            HasElectricity = model.HasElectricity,
//            West=model.West,
//            South=model.South,
//            Rent = model.Rent,
//            North=model.North,
//            HasWater = model.HasWater,
//            HasGas = model.HasGas,
//            IsDeleted=model.IsDeleted,
//            Estate=model.Estate,
//            EstateId=model.EstateId,
//            };
//            db.EstateExtras.Add(extras);
//            db.SaveChanges();

//            return this.Redirect("Index");
//        }
//    }
//}
