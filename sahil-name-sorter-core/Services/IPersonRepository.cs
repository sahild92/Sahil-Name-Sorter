using System.Collections.Generic;
using SahilNameSorterCore.Entities;

namespace SahilNameSorterCore.Services
{
   public interface IPersonRepository
    {
        PersonFullNames Get(int id);
        IEnumerable<PersonFullNames> GetAll();

        IEnumerable<PersonFullNames> GetByName(string firstname, string lastname);
        void Add(PersonFullNames personFullNames);

        bool SaveAll();
    }
}