using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using sahilNameSorterWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace sahilNameSorterWeb.Data
{
    public class PersonSeeder
    {
        private readonly NameSorterContext _ctx;
        private readonly IHostingEnvironment _hosting;

        public PersonSeeder(NameSorterContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated(); //makes sure database exists

            if (!_ctx.PersonFullNames.Any())
            {
                //Create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath,"Data/Names.json");
                var json = File.ReadAllText(filepath);
                var PersonFullNames = JsonConvert.DeserializeObject<IEnumerable<PersonFullNames>>(json);
                _ctx.PersonFullNames.AddRange(PersonFullNames);

                _ctx.SaveChanges();
            }
        }
    }
}
