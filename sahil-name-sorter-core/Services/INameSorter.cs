
using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahilNameSorterCore.Services
{
  public interface INameSorter
    {
        List<Person> Sort(List<Person> people);

    }
}
