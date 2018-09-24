using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SahilNameSorter.Domain;
using SahilNameSorter.Services;
namespace SahilNameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to Sort the Names");
            // Create the IEnumerable data source
            var lines = File.ReadAllLines(@"Data\unsorted-names-list.txt", Encoding.UTF7).Concat(File.ReadAllLines(@"Data\names.txt",Encoding.UTF7)).ToList();

            Console.ReadKey();
            //Print the query output on console
            // Execute the query and write out the new file.
            var peopleService = new PersonService();
            var people = new List<Person>();
            foreach (var line in lines)
            {
                people.Add(new Person(line));
            }
            var sortedNames = new List<Person>();
            Console.WriteLine("Press F for First names OR Press L for Last names Sort");
            string f1 = Console.ReadLine();
            if (f1 == "F")
            {
                Console.WriteLine("Press A for First names in Ascending OR Press D for First names in Decending");
                string d1 = Console.ReadLine();

                if (d1 == "A")
                {
                    INameSorter namesorter = new FirstnameAscending();
                    sortedNames = namesorter.Sort(people);
                }
                else if (d1 == "D")
                {
                    INameSorter namesorter = new FirstnameDecending();
                    sortedNames = namesorter.Sort(people);
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Press A for Last names in Ascending OR Press D for Last names in Decending");
                string s1 = Console.ReadLine();
                if (s1 == "A")
                {
                    INameSorter namesorter = new NameSorterAscending();
                    sortedNames = namesorter.Sort(people);
                }
                else if (s1 == "D")
                {
                    INameSorter namesorter = new NameSorterDecending();
                    sortedNames = namesorter.Sort(people);
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                    Console.ReadKey();
                }
            }
                File.WriteAllLines(@"sorted-names-list.txt", PersonService.GetFullNames(sortedNames));
                Console.WriteLine("Sorted names are written to file. Press any key to exit");
                Console.ReadKey();
            
        }
    }
}