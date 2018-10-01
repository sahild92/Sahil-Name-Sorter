using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sahilNameSorterWeb.Models;

namespace sahilNameSorterWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly INameSorterService nameSorterService;
        public HomeController(INameSorterService nameSorterService)
        {
            this.nameSorterService = nameSorterService;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel { WelcomeMessage = "Welcome to Sort Application" };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel model, IFormFile file)
        {
            var stream = file.OpenReadStream();
            var buffer = new byte[file.Length];

            stream.ReadAsync(buffer).GetAwaiter().GetResult();
            var contents = System.Text.Encoding.UTF7.GetString(buffer);    
            var output1 = nameSorterService.Run(contents, model.Sort, model.Order);                
            var model1 = new HomeViewModel
            {
                output = output1

            };
            return View(model1);
        }
    }      
}