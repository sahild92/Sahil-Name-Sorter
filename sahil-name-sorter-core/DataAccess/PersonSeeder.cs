﻿using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using SahilNameSorterCore.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SahilNameSorterCore.Entities;
using System.Threading.Tasks;

namespace SahilNameSorterCore.DataAccess
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

            if (!_ctx.Person.Any())
            {
                //Create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath,"SeedData/Names.json");
                var json = File.ReadAllText(filepath);
                var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(json);
                _ctx.Person.AddRange(people);

                _ctx.SaveChanges();
            }
        }
    }
}
