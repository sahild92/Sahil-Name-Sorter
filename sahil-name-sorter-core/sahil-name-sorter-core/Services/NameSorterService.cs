
using SahilNameSorterCore.Services;
using System;
using System.Collections.Generic;
using System.IO;
using SahilNameSorterCore.Domain;

namespace SahilNameSorterCore.Services
{
    public class NameSorterService : INameSorterService
    {
        public NameSorterService()
        {

        }

        public List<string> Run(string fileContents, SortType sortType, OrderType orderType)
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

            if (sortType == SortType.firstname)
            {
                if (orderType == OrderType.ascending)
                {
                    INameSorter namesorter = new NameSorterAscending(x => x.FullName);
                    sortedNames = namesorter.Sort(people);
                }
                else if (orderType == OrderType.descending)
                {
                    INameSorter namesorter = new NameSorterDecending(x => x.FullName);
                    sortedNames = namesorter.Sort(people);
                }
            }
            else if (sortType == SortType.lastname)
            {
                if (orderType == OrderType.ascending)
                {
                    INameSorter namesorter = new NameSorterAscending(x => x.Surname);
                    sortedNames = namesorter.Sort(people);
                }
                else if (orderType == OrderType.descending)
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