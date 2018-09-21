using System;
using System.Collections.Generic;
using System.Text;
using SahilNameSorter.Domain;
using System.Linq;
namespace SahilNameSorter.Services
{
    class PersonService
    {
        public static List<string> GetFullNames(List<Person> people)
        {
            var sortedlines = new List<string>();
            foreach (var person in people)
            {
                sortedlines.Add(person.FullName);
            }
            return sortedlines;
        }
    }
}
