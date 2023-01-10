﻿using DiplomenProekt.Data.Models;
using DiplomenProekt.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiplomenProekt.Services
{
    public class DbSeeder:IDataBaseSeeder
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
            await this.CreateEstatesAsync();
            await this.CreateAddressAsync();
        }

        private async Task CreateRolesAsync()
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));//.GetAwaiter().GetResult();
            await roleManager.CreateAsync(new IdentityRole("Waiter"));
        }

        private async Task RegisterUsersAsync()
        {
            var user1 = new AppUser
            {
                UserName = "Administrator",
                Email = "admin@gmail.com",               
            };

            var user2 = new AppUser
            {
                UserName = "SimpleUser",
                Email = "user@abv.bg",
            };
            var pwd = "1234Aa%";

            await userManager.CreateAsync(user1, pwd);
            await userManager.CreateAsync(user2, pwd);
            await userManager.AddToRoleAsync(user1, "Admin");
        }

        private async Task CreateEstatesAsync()
        {
            var estate1 = new Estate
            {
                Price=250000,
                EstateType = EstateType.Flat,
                MainPic = "https://assets-news.housing.com/news/wp-content/uploads/2022/03/15102726/Vastu-for-flats-in-apartments.jpg",
                Pictures = "https://assets-news.housing.com/news/wp-content/uploads/2022/03/15103409/Vastu-for-flats-in-apartments-04.jpg|https://assets-news.housing.com/news/wp-content/uploads/2022/03/15103452/Vastu-for-flats-in-apartments-05.jpg|https://assets-news.housing.com/news/wp-content/uploads/2022/03/15103603/Vastu-for-flats-in-apartments-06.jpg|https://assets-news.housing.com/news/wp-content/uploads/2022/03/15103811/Vastu-for-flats-in-apartments-08.jpg",
                Rooms=5,
                Description="Ново строителство,изолация,измазване,дограма",
                Floor=2,
                MaxFloor=5,
                Area=100
                
            };
            await dbContext.AddAsync(estate1);
            await dbContext.SaveChangesAsync();

        }

        private async Task CreateEstateExtrasAsync()
        {
            var extras1 = new EstateExtras
            {
                HasElectricity = true,
                HasWater = true,
                HasGas = true,
                East = true,
                West = true,
                South = false,
                North = false,
            };
            

            
            await dbContext.SaveChangesAsync();
        }
        private async Task CreateAddressAsync()
        {
            var address1 = new Address
            {
                City = Town.Shumen,
                Neighbourhood = "Училище,Магазин",
                Pics = "data:image/jpeg;base64,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",
                Description = "На центъра,улица Main Street",
            };
            await dbContext.SaveChangesAsync();

        }


    }
}
    public interface IDataBaseSeeder
    {
        Task<bool> HasAnyDataInDBAsync();
        Task InsertDataInDBAsync();
    }

