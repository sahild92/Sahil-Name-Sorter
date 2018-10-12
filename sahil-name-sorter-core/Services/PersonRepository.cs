using SahilNameSorterCore.DataAccess;
using SahilNameSorterCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SahilNameSorterCore.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly NameSorterContext _ctx;

        public PersonRepository(NameSorterContext ctx)
        {
            _ctx = ctx;
        }

        public Person Get(int id)
        {
            return _ctx.Person.Where(person => person.ID == id).FirstOrDefault();
        }

        public IEnumerable<Person> GetByName(string firstname, string lastname, string gender, string fullName)
        {
            var personFullNameEntities = _ctx.Person.Where(person => person.FirstName == firstname && person.Surname == lastname && person.Gender == gender);
            return personFullNameEntities;
        }

        public IEnumerable<Person> GetAll()
        {
            return _ctx.Person
                .OrderBy(p => p.ID)
              
                .ToList();
        }
        public void Add(Person personFullNames)
        {
            _ctx.Person.Add(personFullNames);
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
            
        }
        

    }
}
