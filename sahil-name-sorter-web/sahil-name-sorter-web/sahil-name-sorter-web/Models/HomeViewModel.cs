using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sahilNameSorterWeb.Models
{
    public class HomeViewModel
{
        public string WelcomeMessage { get; set; }
        public List<string> output { get; set; }
        public HomeViewModel()
        {
            output = new List<string>();
        }
     
    }
}
