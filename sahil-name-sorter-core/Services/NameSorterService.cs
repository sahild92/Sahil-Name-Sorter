
using SahilNameSorterCore.Services;
using System;
using System.Collections.Generic;
using System.IO;
using SahilNameSorterCore.Domain;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sahil_name_sorter_core.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace SahilNameSorterCore.Services
{
    public class NameSorterService : INameSorterService
    {
        private IMemoryCache _cache;
        private readonly IGenderizeClient client;
        public NameSorterService(IGenderizeClient client, IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            this.client = client;
        }

        public async Task<List<Person>> Run(string fileContents, SortType sortType, OrderType orderType)
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

            foreach(var person in sortedNames)
            {
               var cacheResult = _cache.Get<GenderizeResult>(person.FirstName);
                if (cacheResult == null)
                {
                    var jsonResponse = await client.GetGender(person.FirstName);
                    var genderObject = JsonConvert.DeserializeObject<GenderizeResult>(jsonResponse);
                    
                    
                        person.Gender = genderObject.gender;
                        var saveCache = _cache.Set(person.FirstName, genderObject);
                    
                }
                else
                {
                    person.Gender = cacheResult.gender;
                }
            }
            var sortedLines = PersonService.GetFullNames(sortedNames);
            File.WriteAllLines(@"sorted-names-list.txt", sortedLines);
            Console.WriteLine("Sorted names are written to file. Press any key to exit");
            return sortedNames;

        }
    }
}