using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data
{
    /// <summary>
    /// We need this in ordeer to have smooth migration update. On Web Api start. Use by default.
    /// </summary>
    public class ApiTestFactory : IDesignTimeDbContextFactory<ApiTestContext>
    {
        public ApiTestContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TestConnectionString");

            var builder = new DbContextOptionsBuilder<ApiTestContext>();

            builder.UseMySQL(connectionString);

            return new ApiTestContext(builder.Options);
        }
    }
}
