using System.Linq;
namespace SahilNameSorter.Domain
{
    public class Person
    {
        public string FullName { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public Person(string fullName)
        {
            var nameComponents = fullName.Split(' ');
            Surname = nameComponents.Last();
            FirstName = nameComponents.First();
            FullName = fullName;
        }
    }
}