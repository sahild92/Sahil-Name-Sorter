using System;
using System.Collections.Generic;
using System.Linq;
using SahilNameSorter.Domain;
using SahilNameSorter.Services;
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
            Console.WriteLine("Press A for names in Ascending OR Press D for names in Decending");
            string s1 = Console.ReadLine();
            //Print the query output on console
            // Execute the query and write out the new file.
            var peopleService = new PersonService();
            var people = new List<Person>();
            foreach(var line in lines)
            {
                people.Add(new Person(line));
            }
            var sortedNames = new List<Person>();
            if (s1 == "A")
            {
                 sortedNames = peopleService.Sort(people);
               
            }
            else if (s1 == "D")
            {
                 sortedNames = peopleService.SortbyDecending(people);
            }
            else
            {
                Console.WriteLine("Invalid Selection");
                Console.ReadKey();
            }
            System.IO.File.WriteAllLines(@"sorted-names-list.txt", PersonService.GetFullNames(sortedNames));
            Console.WriteLine("Sorted names are written to file. Press any key to exit");
            Console.ReadKey();
        }
    }
}