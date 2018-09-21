using SahilNameSorter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SahilNameSorter.Services
{
    class NameSorterDecending : INameSorter
    {
        public List<Person> Sort(List<Person> people)
        {
            var sortedPeopledec = people.OrderByDescending(x => x.Surname).ToList();
            return sortedPeopledec;
        }
    }
}
