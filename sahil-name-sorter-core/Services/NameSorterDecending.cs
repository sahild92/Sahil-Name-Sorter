
using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SahilNameSorterCore.Services
{
    public class NameSorterDecending : INameSorter
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
