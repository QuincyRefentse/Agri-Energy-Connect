using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Agri_Energy_Connect.Data;

namespace Agri_Energy_Connect.Data
{
    public class AgriDbContextFactory : IDesignTimeDbContextFactory<AgriDbContext>
    {
        public AgriDbContext CreateDbContext(string[] args)
        {
            // Set up configuration to access the appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // Set the path to the current directory
                .AddJsonFile("appsettings.json")  // Assuming you're using appsettings.json
                .Build();

            // Create options for HRDbContext
            var optionsBuilder = new DbContextOptionsBuilder<AgriDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));  // Replace with your connection string name

            // Return the HRDbContext instance with the configured options
            return new AgriDbContext(optionsBuilder.Options);
        }
    }
}
