using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace StaffCoreRD.Data
{
    public class StaffDbContextFactory : IDesignTimeDbContextFactory<StaffDbContext>
    {
        public StaffDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<StaffDbContext>();
            var connectionString = config.GetConnectionString("StaffCore");
            optionsBuilder.UseSqlServer(connectionString);

            return new StaffDbContext(optionsBuilder.Options);
        }
    }
}