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
                  var lines = System.IO.File.ReadAllLines(@"unsorted-names-list.txt");
                    Console.ReadKey();
            // Create the query. Put field 2 first, then  
            // reverse and combine fields 0,1,2 and 3 from the old field  
            IEnumerable<Person> query =
            from line in lines
            select new Person(line);
            var people = query.ToList();
            var query2 = from person in people
                         orderby person.Surname
                         select person.FullName;
            //Print the query output on console
            // Execute the query and write out the new file. 
             System.IO.File.WriteAllLines(@"sorted-names-list.txt", query2.ToArray());
            Console.WriteLine("Sorted names are written to file. Press any key to exit");
                Console.ReadKey();
            }
       
    }
}