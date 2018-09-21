using SahilNameSorter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SahilNameSorter.Services
{
    class NameSorterAscending : INameSorter
    {
        public List<Person> Sort(List<Person> people)
        {
            var sortedPeople = people.OrderBy(x => x.Surname).ToList();
            return sortedPeople;
        }
    }
}
