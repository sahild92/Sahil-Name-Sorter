using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Services;

namespace sahilNameSorterWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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
            services.AddMvc();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration, IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(configureRoutes);

            app.Run(async (context) =>
            {
                var greeting = greeter.ReadFile();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(greeting);

            });

        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {

            routeBuilder.MapRoute("File Location", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
