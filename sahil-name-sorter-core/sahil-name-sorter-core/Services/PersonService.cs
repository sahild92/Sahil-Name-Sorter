using System;
using System.Collections.Generic;
using System.Text;
using SahilNameSorter.Domain;
using System.Linq;
namespace SahilNameSorter.Services
{
    class PersonService
    {
     /* public List<Person> Sort(List<Person> people)
        {
            var sortedPeople = people.OrderBy(x => x.Surname).ToList();
            return sortedPeople;
        } 
        public List<Person> SortbyDecending(List<Person> people)
        {
            var sortedPeopledec = people.OrderByDescending(x => x.Surname).ToList();
            return sortedPeopledec;
        } */
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
