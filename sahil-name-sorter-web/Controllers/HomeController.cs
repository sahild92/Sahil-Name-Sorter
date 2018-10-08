using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Services;
using sahilNameSorterWeb.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.Extensions.Caching.Memory;

namespace sahilNameSorterWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly INameSorterService nameSorterService;
        private readonly IGenderizeClient client;

        public HomeController(INameSorterService nameSorterService, IGenderizeClient client)
        {
            this.nameSorterService = nameSorterService;
            this.client = client;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel { WelcomeMessage = "Welcome to Sort Application" };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeViewModel model, IFormFile file)
        {
           
            if (file == null)
            {
                ViewBag.ResultErrorMessage = "No file was chosen.";
                return View(new HomeViewModel());
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stream = file.OpenReadStream();
            var buffer = new byte[file.Length];

            stream.ReadAsync(buffer).GetAwaiter().GetResult();
            var contents = System.Text.Encoding.UTF7.GetString(buffer);
            var output1 = await nameSorterService.Run(contents, model.Sort, model.Order);
            var sortedLines = PersonService.GetFullNames(output1);

            var model1 = new HomeViewModel
            {
                Sortedpeople = output1

            };
            return View(model1);

        }
        

    }
}
