using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
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
