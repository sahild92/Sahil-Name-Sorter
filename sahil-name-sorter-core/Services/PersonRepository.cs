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

        public PersonFullNames Get(int id)
        {
            return _ctx.PersonFullNames.Where(person => person.ID == id).FirstOrDefault();
        }

        public IEnumerable<PersonFullNames> GetByName(string firstname, string lastname)
        {
            var personFullNameEntities = _ctx.PersonFullNames.Where(person => person.FirstName == firstname && person.LastName == lastname);

            return personFullNameEntities;
        }

        public IEnumerable<PersonFullNames> GetAll()
        {
            return _ctx.PersonFullNames
                .OrderBy(p => p.ID)
              
                .ToList();
        }
        public void Add(PersonFullNames personFullNames)
        {
            _ctx.PersonFullNames.Add(personFullNames);
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
            
        }
        

    }
}
