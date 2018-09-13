using SahilNameSorter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace sahilnamesorter.Domain.Tests
{
   public class PersonTests
    {
        [Fact]
        public void ShouldHaveSurname()
        {
            //Arange & act
            var s = new Person("Sahil Deshpande");

            //assert
            Assert.Equal("Deshpande", s.Surname);
        
        }
    }
}
