using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SahilNameSorterCore.Services
{
    public interface INameSorterService
    {
        Task<List<Person>> Run(string fileContents, SortType sortType, OrderType orderType);
    }
}