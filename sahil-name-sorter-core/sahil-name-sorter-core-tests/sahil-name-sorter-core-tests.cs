using SahilNameSorter.Domain;
using System;
using Xunit;

namespace SahilNameSorter.Tests
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
        [Fact]
        public void Nullcheck()
        {
            var s = new Person("Buth Arthur Post Archer");

            Assert.NotNull(s.Surname);
        }
    }
}
