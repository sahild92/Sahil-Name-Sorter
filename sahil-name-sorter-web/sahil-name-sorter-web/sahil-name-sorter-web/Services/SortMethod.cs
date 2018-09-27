
using System;
using System.Collections.Generic;
using System.Text;

namespace sahilNameSorterWeb.Services
{
    interface INameSorter
    {
        List<Person> Sort(List<Person> people);

    }
}
