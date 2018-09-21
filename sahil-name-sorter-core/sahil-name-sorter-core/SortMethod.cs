using SahilNameSorter.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahilNameSorter.Services
{
    interface INameSorter
    {
        List<Person> Sort(List<Person> people);

    }
}
