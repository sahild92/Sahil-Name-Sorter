using System.Collections.Generic;
using SahilNameSorterCore.Entities;

namespace SahilNameSorterCore.Services
{
   public interface IPersonRepository
    {
        Person Get(int id);
        IEnumerable<Person> GetAll();

        IEnumerable<Person> GetByName(string firstname, string lastname, string gender);
        void Add(Person personFullNames);

        bool SaveAll();
    }
}