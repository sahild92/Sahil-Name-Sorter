using sahilNameSorterWeb.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace sahilNameSorterWeb
{
    public class NameSorterService : INameSorterService
    {
        public NameSorterService()
        {

        }

        public List<string> Run(string fileContents, bool firstnameOption, bool lastnameOption, bool NameAscendingOption, bool NameDecendingOption)
        {
            var lines = fileContents.Split(Environment.NewLine);
            //Print the query output on console
            // Execute the query and write out the new file.
            var peopleService = new PersonService();
            var people = new List<Person>();
            foreach (var line in lines)
            {
                people.Add(new Person(line));
            }
            var sortedNames = new List<Person>();

            if (firstnameOption)
            {
                if (NameAscendingOption)
                {
                    INameSorter namesorter = new NameSorterAscending(x => x.FullName);
                    sortedNames = namesorter.Sort(people);
                }
                else if (NameDecendingOption)
                {
                    INameSorter namesorter = new NameSorterDecending(x => x.FullName);
                    sortedNames = namesorter.Sort(people);
                }
            }
            else if (lastnameOption)
            {
                if (NameAscendingOption)
                {
                    INameSorter namesorter = new NameSorterAscending(x => x.Surname);
                    sortedNames = namesorter.Sort(people);
                }
                else if (NameDecendingOption)
                {
                    INameSorter namesorter = new NameSorterDecending(x => x.Surname);
                    sortedNames = namesorter.Sort(people);
                }
            }
            var sortedLines = PersonService.GetFullNames(sortedNames);
            File.WriteAllLines(@"sorted-names-list.txt", sortedLines);
            Console.WriteLine("Sorted names are written to file. Press any key to exit");
            return sortedLines;
        }
    }
}