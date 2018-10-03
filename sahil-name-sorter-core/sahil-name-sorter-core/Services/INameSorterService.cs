using SahilNameSorterCore.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SahilNameSorterCore.Services
{
    public interface INameSorterService
    {
        Task<List<string>> Run(string fileContents, SortType sortType, OrderType orderType);
    }
}