using SahilNameSorter.Domain;
using System;
using Xunit;
using SahilNameSorter;

namespace SahilNameSorter.Tests
{
    public class PersonTests
    {
        [Fact]
        public void AcceptsLastLetterAsSurname()
        {
            //Arange & act
            var s = new Person("Sahil Deshpande");

            //assert
            Assert.Equal("Deshpande", s.Surname);

        }
        [Fact]
        public void SurnameNullcheck()
        {
            var s = new Person("Buth Arthur Post Archer");

            Assert.NotNull(s.Surname);
        }
     
    }
}
