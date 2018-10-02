
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sahilNameSorterWeb.Services
{
    class NameSorterAscending : INameSorter
    {
        public readonly Func<Person, string> propertyFunc;

        public NameSorterAscending(Func<Person, string> propertyFunc)
        {
            this.propertyFunc = propertyFunc;
        }

        public List<Person> Sort(List<Person> people)
        {
            var sortedPeopledec = people.OrderBy(this.propertyFunc).ToList();
            return sortedPeopledec;
        }
    }
}
