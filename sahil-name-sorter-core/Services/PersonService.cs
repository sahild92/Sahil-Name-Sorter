using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Entities;

namespace SahilNameSorterCore.Services
{
    public class PersonService
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