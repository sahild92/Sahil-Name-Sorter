using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace sahilNameSorterWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Adding JSON file into IConfiguration.
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                //.AddUserSecrets("0")
                .Build();

            // Read instrumentation key from IConfiguration.
            string ikey = config["ApplicationInsights:InstrumentationKey"];

            CreateWebHostBuilder(args, ikey).Build().Run();
            
        }

      

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, string appInsightsKey) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights(appInsightsKey)
                .UseStartup<Startup>();
    }
}
