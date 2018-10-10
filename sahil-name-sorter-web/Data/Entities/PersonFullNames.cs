using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sahilNameSorterWeb.Data.Entities
{
    public class PersonFullNames
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string MiddleNameOptional { get; set; }
        public string LastName { get; set; }

    }
}
