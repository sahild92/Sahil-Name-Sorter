
using System;
using System.Collections.Generic;
using System.Linq;
namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the IEnumerable data source  
            string[] lines = System.IO.File.ReadAllLines(@"C:\repos\internal\Internal\ConsoleApp5\unsorted-names-list.txt");

            // Create the query. Put field 2 first, then  
            // reverse and combine fields 0,1,2 and 3 from the old field  
            IEnumerable<string> query =
                from line in lines
                let x = line.Split(',')
                orderby x[3]
                select x[3] + ", " + x[2] + ", " + x[1] + ", " + x[0];
            // Execute the query and write out the new file. 
            System.IO.File.WriteAllLines(@"C:\repos\internal\Internal\ConsoleApp5\sorted-names-list.txt", query.ToArray());
            Console.WriteLine("Sorted names are written to disk. Press any key to exit");
            Console.ReadKey();
        }
    }
}
