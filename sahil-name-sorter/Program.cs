using System;
using System.Collections.Generic;
using System.Linq;
using SahilNameSorter.Domain;
namespace SahilNameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to Sort Last Name");
            // Create the IEnumerable data source  
            var lines = System.IO.File.ReadAllLines(@"unsorted-names-list.txt").ToList();
            Console.ReadKey();
            // Create the query. Put field 2 first, then  
            // reverse and combine fields 0,1,2 and 3 from the old field  
            /*   IEnumerable<Person> query =
               from line in lines
               select new Person(line);
               var people = query.ToList();
               var query2 = from person in people
                            orderby person.Surname
                            select person.FullName; */
            /*  var people = new List<Person>();
                       foreach (var line in lines)
                       {
                           people.Add(new Person(line));
                       } 
                       var sortedPeople = people.OrderBy(x => x.Surname).ToList();   */
            //Print the query output on console
            // Execute the query and write out the new file. 
            var sortedNames = SortBySurname(lines);
            System.IO.File.WriteAllLines(@"sorted-names-list.txt", GetFullNames(sortedNames));
            Console.WriteLine("Sorted names are written to file. Press any key to exit");
            Console.ReadKey();
        }
        public static List<string> GetFullNames(List<Person> people)
        {
            var sortedlines = new List<string>();
            foreach (var person in people)
            {
                sortedlines.Add(person.FullName);
            }
            return sortedlines;
        }

        public static List<Person> SortBySurname(List<string> lines)
        {
            var people = new List<Person>();
            foreach (var line in lines)
            {
                people.Add(new Person(line));
            }
            var sortedPeople = people.OrderBy(x => x.Surname).ToList();
            return sortedPeople;
        }
        
     
    }
}
