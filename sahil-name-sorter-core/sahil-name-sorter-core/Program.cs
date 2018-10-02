using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Services;
using Microsoft.Extensions.CommandLineUtils;
using System.Reflection;


namespace SahilNameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.Name = "sahil-name-sorter-core";

            var basicOption = app.Option("-fp|--filepath",
                   "provides the name file for input",
                   CommandOptionType.SingleValue);

            var firstnameOption = app.Option("-f|--firstname",
                   "input data is firstname first",
                   CommandOptionType.NoValue);

            var lastnameOption = app.Option("-l|--lastname",
               "Input data is lastname first",
               CommandOptionType.NoValue);

            var NameAscendingOption = app.Option("-a|--NameAscending",
                   "input data is firstname ascending first",
                   CommandOptionType.NoValue);

            var NameDecendingOption = app.Option("-d|--NameDecending",
                   "input data is firstname decending first",
                   CommandOptionType.NoValue);
            app.HelpOption("-?|-h|--help");

            //  app.Description = "To sort names first specify the filepath followed by the firstname/lastname and lastly Ascending/Decending ";
            app.VersionOption("-v|--version", () => {
                return string.Format("Version {0}", Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
            });
            ;
            app.OnExecute(() =>
            {
                Console.WriteLine("simple-command is executing");
                if (firstnameOption.HasValue() && lastnameOption.HasValue())
                {
                    throw new Exception("Cannot specify the first name and last name together");
                }

                if (NameAscendingOption.HasValue() && NameAscendingOption.HasValue())
                {
                    throw new Exception("Cannot specify the ascending and decending together");
                }
                Run(basicOption, firstnameOption.HasValue(), lastnameOption.HasValue(), NameAscendingOption.HasValue(), NameDecendingOption.HasValue());

                Console.WriteLine("simple-command has finished.");
                return 0; //return 0 on a successful execution
            });

            // Create the IEnumerable data source
            try
            {
                // This begins the actual execution of the application
                Console.WriteLine("ConsoleArgs app executing...");
                app.Execute(args);
            }
            catch (CommandParsingException ex)
            {
                // You'll always want to catch this exception, otherwise it will generate a messy and confusing error for the end user.
                // the message will usually be something like:
                // "Unrecognized command or argument '<invalid-command>'"
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to execute application: {0}", ex.Message);
            }
        }
        private static void Run(CommandOption basicOption, bool firstnameOption, bool lastnameOption, bool NameAscendingOption, bool NameDecendingOption)
        {
            var lines = File.ReadAllLines(basicOption.Value(), Encoding.UTF7).ToList();
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
                    INameSorter namesorter = new NameSorterAscending(x => x.FirstName);
                    sortedNames = namesorter.Sort(people);
                }
                else if (NameDecendingOption)
                {
                    INameSorter namesorter = new NameSorterDecending(x => x.FirstName);
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
            File.WriteAllLines(@"sorted-names-list.txt", PersonService.GetFullNames(sortedNames));
            Console.WriteLine("Sorted names are written to file. Press any key to exit");
            Console.ReadKey();
        }
    }
}