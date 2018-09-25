using SahilNameSorter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SahilNameSorter.Services
{
    class NameSorterDecending : INameSorter
    {
        private readonly Func<Person, string> propertyFunc;

        public NameSorterDecending(Func<Person, string> propertyFunc)
        {
            this.propertyFunc = propertyFunc;
        }

        public List<Person> Sort(List<Person> people)
        {
            var sortedPeopledec = people.OrderByDescending(this.propertyFunc).ToList();
            return sortedPeopledec;
        }
    }
}
