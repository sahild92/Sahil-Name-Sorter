using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SahilNameSorterCore.DataAccess;
using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Services;

namespace sahilNameSorterWeb
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug()
                .AddAzureWebAppDiagnostics());
            services.AddDbContext<NameSorterContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("NameSorterConnectionString"));
            });
            services.AddLogging();
            services.AddScoped<INameSorterService, NameSorterService>();
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<INameSorter, NameSorterAscending>();
            services.AddScoped<INameSorter, NameSorterDecending>();
            services.AddHttpClient("gendrizeClient", client =>
            {
                client.BaseAddress = new Uri("https://api.genderize.io/");
                client.Timeout = TimeSpan.FromMinutes(1);
            });
            services.AddHttpClient();
            // services.AddHttpClient<IGenderizeClient, GenderizeClient>();
            services.AddTransient<IGenderizeClient, GenderizeClient>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddMvc()
                    .AddControllersAsServices();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration, ILoggerFactory loggerFactory,
            NameSorterContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(configureRoutes);

            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Information);


            if (env.IsDevelopment())
            {
                context.Database.Migrate();
            }
            //app.Run(async (context) =>
            //{
            //    var greeting = greeter.ReadFile();
            //    context.Response.ContentType = "text/plain";
            //    await context.Response.WriteAsync(greeting);

            //});

        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {

            routeBuilder.MapRoute("File Location", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
