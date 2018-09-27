using System.Collections.Generic;

namespace sahilNameSorterWeb
{
    public interface INameSorterService
    {
        List<string> Run(string fileContents, bool firstnameOption, bool lastnameOption, bool NameAscendingOption, bool NameDecendingOption);
    }
}