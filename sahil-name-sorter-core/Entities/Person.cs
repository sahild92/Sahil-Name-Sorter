using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace SahilNameSorterCore.Entities
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }     
        public string FullName { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }

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