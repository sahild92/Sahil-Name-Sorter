using System.Linq;
namespace sahilNameSorterWeb.Services
{
    public class Person
    {
        public string FullName { get; set; }
        public string Surname { get; set; }
        public Person(string fullName)
        {
            var nameComponents = fullName.Split(' ');
            Surname = nameComponents.Last();
            FullName = fullName;
        }
    }
}