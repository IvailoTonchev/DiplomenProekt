using DiplomenProekt.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DiplomenProekt.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {             
        }
        public DbSet<Estate>Estates { get; set; }
        public DbSet<EstateExtras>EstateExtras { get; set; }
        public DbSet<Address>Addresses { get; set; }
    }
}