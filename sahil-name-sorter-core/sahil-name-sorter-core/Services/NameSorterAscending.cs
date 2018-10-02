using SahilNameSorterCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SahilNameSorterCore.Services
{
   public class NameSorterAscending : INameSorter
    {
        private readonly Func<Person, string> propertyFunc;

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
