using SahilNameSorterCore.Domain;
using System.Collections.Generic;

namespace SahilNameSorterCore.Services
{
    public interface INameSorterService
    {
        List<string> Run(string fileContents, SortType sortType, OrderType orderType);
    }
}