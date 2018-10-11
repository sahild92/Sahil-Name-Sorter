using System.Linq;
namespace SahilNameSorterCore.Entities
{
    public class Person
    {
        public string FullName { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public int ID { get; set; }
        public Person()
        {

        }
        public Person(string fullName)
        {
            var nameComponents = fullName.Split(' ');
            Surname = nameComponents.Last();
            FirstName = nameComponents.First();
            FullName = fullName;
        }
    }
}