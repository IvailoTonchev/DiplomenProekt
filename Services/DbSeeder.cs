using DiplomenProekt.Data.Models;
using DiplomenProekt.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;


namespace DiplomenProekt.Services
{
    public class DbSeeder : IDataBaseSeeder
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DbSeeder(ApplicationDbContext dbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<bool> HasAnyDataInDBAsync() =>
                   await roleManager.Roles.AnyAsync();

        public async Task InsertDataInDBAsync()
        {
            await this.CreateRolesAsync();
            await this.RegisterUsersAsync();
            await this.CreateAddressAsync();
            await this.CreateEstatesAsync();
            await this.CreateEstateExtrasAsync();
        }

        private async Task CreateRolesAsync()
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Broker"));
        }

        private async Task RegisterUsersAsync()
        {
            var user1 = new AppUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
            };

            var user2 = new AppUser
            {
                UserName = "broker@abv.bg",
                Email = "broker@abv.bg",
            };
            var user3 = new AppUser
            {
                UserName = "user@abv.bg",
                Email = "user@abv.bg",
            };
            var pwd = "1234Aa%";

            await userManager.CreateAsync(user1, pwd);
            await userManager.CreateAsync(user2, pwd);
            await userManager.CreateAsync(user3, pwd);
            await userManager.AddToRoleAsync(user1, "Admin");
            await userManager.AddToRoleAsync(user2, "Broker");
        }

        private async Task CreateAddressAsync()
        {
            var square1 = new Address
            {
                City = Town.Shumen,
                Neighbourhood = "Пети Полк",
                Pics = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfXZUKqD_73wfugGzfQbJhM1fboSyPV1uOtyeZYyfkzhAHh--vJgbh67yCZ0MoDHL4_q0&usqp=CAU|https://radian.bg/wp-content/uploads/2017/12/rsz_20171212_103747-1.jpg",
                Description = "Близо до Арена Шумен и до Гръцкия блок.",

            };
            var square2 = new Address
            {
                City = Town.Shumen,
                Neighbourhood = "Гривица",
                Pics= "https://m.netinfo.bg/media/images/37404/37404894/991-ratio-grivica-non-stop.jpg|https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3BpWe3uP2SMdxgHwlKQtkUNmXRa4Kc-DgAw&usqp=CAU",
                Description = "Училище, Магазин, Старчески дом, Планина и чист въздух. Много спокоен район.",
            };


            await dbContext.AddRangeAsync(new[] { square1, square2 });
            await dbContext.SaveChangesAsync();

        }
        private async Task CreateEstatesAsync()
        {
            var addresses = await dbContext.Addresses.ToArrayAsync();
            var estate1 = new Estate
            {
                Price = 250000,
                EstateType = EstateType.Flat,
                MainPic = "https://assets-news.housing.com/news/wp-content/uploads/2022/03/28143140/Difference-between-flat-and-apartment.jpg",
                Pictures = "https://assets-news.housing.com/news/wp-content/uploads/2022/03/15103409/Vastu-for-flats-in-apartments-04.jpg|https://assets-news.housing.com/news/wp-content/uploads/2022/03/15103452/Vastu-for-flats-in-apartments-05.jpg|https://assets-news.housing.com/news/wp-content/uploads/2022/03/15103603/Vastu-for-flats-in-apartments-06.jpg|https://assets-news.housing.com/news/wp-content/uploads/2022/03/15103811/Vastu-for-flats-in-apartments-08.jpg",
                Rooms = 5,
                Description = "Ново строителство,изолация,измазан,дограма",
                Floor = 2,
                MaxFloor = 5,
                Area = 100,
                Address = addresses[0],
            };

            var estate2 = new Estate
            {
                Price = 130001,
                EstateType = EstateType.Flat,
                MainPic = "https://cdn.confident-group.com/wp-content/uploads/2021/08/26224309/oakwood_gallery_image.jpg",
                Pictures = "https://unisondesignbg.com/wp-content/uploads/2020/08/2-%D0%B0%D0%BF%D0%B0%D1%80%D1%82%D0%B0%D0%BC%D0%B5%D0%BD%D1%82-%D0%B4%D0%BD%D0%B5%D0%B2%D0%BD%D0%B0-%D0%B2%D0%B8%D0%B7%D1%83%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F-%D0%B8%D0%BD%D1%82%D0%B5%D1%80%D0%B8%D0%BE%D1%80%D0%B5%D0%BD-%D0%B4%D0%B8%D0%B7%D0%B0%D0%B9%D0%BD-%D0%BC%D0%BE%D0%B4%D0%B5%D1%80%D0%B5%D0%BD-%D1%85%D0%BE%D0%BB-apartament-design-proekt-3d-vizualizaciq-Unison-Design-%D0%A0%D0%B0%D0%BB%D0%B0%D1%86%D0%B0-%D0%97%D0%B0%D0%BF%D1%80%D1%8F%D0%BD%D0%BE%D0%B2%D0%B0.jpg|http://www.combo.bg/wp-content/uploads/2016/01/%D0%9A%D1%80%D0%B0%D1%81%D0%B8%D0%B2-%D0%B0%D0%BF%D0%B0%D1%80%D1%82%D0%B0%D0%BC%D0%B5%D0%BD%D1%82-%D0%A1%D0%BE%D1%84%D0%B8%D1%8F-70-%D0%BA%D0%B2.-%D0%BC_2.jpg",
                Rooms = 4,
                Description = @"Просторен дневен тракт
Голяма спалня
Обширна кухня
2 тераси
Баня с тоалет
Г-образен коридор с дрешник и ниша подходяща за мокро помещение
Изба
Разпределението и големината на помещенията позволява апартаментът да бъде преустроен на тристаен /с 2 спални/. Подовите настилки са от естествен паркет в много добро състояние и теракота в коридора и банята. PVC дограма на всички стаи и едната тераса. До входа на банята има ниша подходяща за перално помещение, а зад входната врата голям и дълбок вграден гардероб. Апартаментът се предлага с наличното обзавеждане от снимките, но при желание може да бъде премахнато.

Сградата, в която се намира жилището е с перфектна локация в непосредствена близост до Руски паметник, но същевременно с достатъчно междублоково пространство за паркиране. Блокът е в много добро състояние с поддържани общи части и контролиран достъп.",
                Floor = 10,
                MaxFloor = 14,
                Area = 78.3,
                Address = addresses[1],

            };
            await dbContext.AddRangeAsync(new[] { estate1, estate2 });
            await dbContext.SaveChangesAsync();
        }

        private async Task CreateEstateExtrasAsync()
        {
            var estates = dbContext.Estates.ToArray();
            var extras = new[]{ new EstateExtras
            {
                HasElectricity = true,
                HasWater = true,
                HasGas = true,
                East = true,
                West = true,
                South = false,
                North = false,
                Elevator = true,
                Rent=false,
                Estate = estates[0]
            } ,
                new EstateExtras
            {
                HasElectricity = true,
                HasWater = true,
                HasGas = false,
                East = false,
                West = true,
                South = true,
                North = false,
                Elevator=true,
                Rent=false,
                Estate = estates[1],
            } ,
            };


            await dbContext.AddRangeAsync(extras);
            await dbContext.SaveChangesAsync();
        }


    }
}
public interface IDataBaseSeeder
{
    Task<bool> HasAnyDataInDBAsync();
    Task InsertDataInDBAsync();
}

