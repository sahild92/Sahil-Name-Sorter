using sahilNameSorterWeb.Models;
using System.Collections.Generic;

namespace sahilNameSorterWeb
{
    public interface INameSorterService
    {
        List<string> Run(string fileContents, SortType sortType, OrderType orderType);
    }
}