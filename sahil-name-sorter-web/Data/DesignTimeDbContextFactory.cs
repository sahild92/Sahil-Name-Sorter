using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace sahilNameSorterWeb.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NameSorterContext>
    {
        public NameSorterContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<NameSorterContext>();

            var connectionString = configuration.GetConnectionString("NameSorterConnectionString");

            builder.UseSqlServer(connectionString);

            return new NameSorterContext(builder.Options);
        }
    }
}
