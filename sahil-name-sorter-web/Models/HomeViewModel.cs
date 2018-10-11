using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public List<Person> Sortedpeople { get; set; }

        public string ErrorMessage { get; set; }

        [Required(ErrorMessage = "input string is required")]
        [StringLength(10)]
        public string inputString { get; set; }
        public HomeViewModel()
        {
            Sortedpeople = new List<Person>();
        }
        public Gender gender { get; set; }

    }
}
