using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sahilNameSorterWeb.Models
{
    public class HomeViewModel
{
        public string WelcomeMessage { get; set; }
        [Required(ErrorMessage = "Type is required.")]
        public OrderType Order { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public SortType Sort { get; set; }
        //public IFormFile FileStream { get; set; }
        public List<string> output { get; set; }
        public HomeViewModel()
        {
            output = new List<string>();
        }
     
    }
}
