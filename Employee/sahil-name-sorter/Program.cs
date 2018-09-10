
using System;
using System.Collections.Generic;
using System.Linq;
namespace SahilNameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to Sort Last Name");
                // Create the IEnumerable data source  
                string[] lines = System.IO.File.ReadAllLines(@"Employee Files\unsorted-names-list.txt");
            Console.ReadKey();
            // Create the query. Put field 2 first, then  
            // reverse and combine fields 0,1,2 and 3 from the old field  
            IEnumerable<string> query =
                from line in lines
                let x = line.Split(' ')
                orderby x[3]
                select x[0] + " " + x[1] + " " + x[2] + " " + x[3];
            //Print the query output on console
            Console.WriteLine("{0}", string.Join(", ", query.ToArray()));
            // Execute the query and write out the new file. 
            System.IO.File.WriteAllLines(@"Employee Files\sorted-names-list.txt", query.ToArray());
            Console.WriteLine("Sorted names are written to file. Press any key to exit");
            
            Console.ReadKey();
        }
    }
}
