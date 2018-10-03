using System;
using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Services;
using Microsoft.Extensions.CommandLineUtils;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

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
            app.VersionOption("-v|--version", () =>
            {
                return string.Format("Version {0}", Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
            });
            ;
            app.OnExecute(() =>
            {

                Console.WriteLine("simple-command is executing");


                //setup our DI
                var serviceProvider = new ServiceCollection()
                    .AddScoped<INameSorterService, NameSorterService>()
                    .AddSingleton<IGreeter, Greeter>()
                    .AddScoped<INameSorter, NameSorterAscending>()
                    .AddScoped<INameSorter, NameSorterDecending>()
                    .AddHttpClient("gendrizeClient", client =>
                    {
                        client.BaseAddress = new Uri("https://api.genderize.io/");
                        client.Timeout = TimeSpan.FromMinutes(1);
                    }).Services
                    .AddHttpClient()
                    // services.AddHttpClient<IGenderizeClient, GenderizeClient>();
                    .AddTransient<IGenderizeClient, GenderizeClient>()
                    .BuildServiceProvider();

                if (firstnameOption.HasValue() && lastnameOption.HasValue())
                {
                    throw new Exception("Cannot specify the first name and last name together");
                }

                if (NameAscendingOption.HasValue() && NameDecendingOption.HasValue())
                {
                    throw new Exception("Cannot specify the ascending and decending together");
                }
                var sortType = SortType.firstname;
                if (lastnameOption.HasValue())
                {
                    sortType = SortType.lastname;
                }
                var orderType = OrderType.ascending;
                if (NameDecendingOption.HasValue())
                {
                    orderType = OrderType.descending;
                }
                //     Run(basicOption, firstnameOption.HasValue(), lastnameOption.HasValue(), NameAscendingOption.HasValue(), NameDecendingOption.HasValue());
                var fileContents = System.IO.File.ReadAllText(basicOption.Value(), Encoding.UTF7);

                var nameSorterService = serviceProvider.GetService<INameSorterService>();
                var sortedPeople = nameSorterService.Run(fileContents, sortType, orderType).GetAwaiter().GetResult();
                foreach(var person in sortedPeople)
                {
                    Console.WriteLine($"FirstName {person.FirstName}, FullName {person.FullName}, Gender {person.Gender} ");
                }
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

      /*  public static void GenderType(List<string> sortedNames)
        {
            List<string> genderType = new List<string>();
            foreach (string n in sortedNames)
            {
                string apiData = GetAPIData(n);
                List<String> thisName = ParseData(apiData);
                double prob = Convert.ToDouble(thisName[1]) * 100;
                string thisData = null;
                if (!String.IsNullOrEmpty(thisName[0])) thisData = "The name '" + n + "' has a " + prob + "% chance of being a " + thisName[0] + ".";
                else continue;
                genderType.Add(thisData);
            }*/

        }

    }

