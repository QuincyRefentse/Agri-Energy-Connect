

using Agri_Energy_Connect.Models;

using Microsoft.EntityFrameworkCore; // For DbContext, DbSet

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Agri_Energy_Connect.Models;
using AgriEnergyConnect.Models;


namespace Agri_Energy_Connect.Data
{
    public class AgriDbContext : IdentityDbContext
    {
        public AgriDbContext(DbContextOptions<AgriDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Farmer> Farmers { get; set; }

        public DbSet<Employee> Employees { get; set; }


    }

}


