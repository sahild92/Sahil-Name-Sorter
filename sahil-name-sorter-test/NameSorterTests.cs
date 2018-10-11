using SahilNameSorterCore.Domain;
using SahilNameSorterCore.Entities;
using SahilNameSorterCore.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace sahilnamesorter.Tests
{
   public class NameSorterTests
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
        public void ShouldReturnFullname()
        {
            //Arrange & act
            var s = new Person("Chris Morris");
            //Assert
            Assert.Equal("Chris Morris", s.FullName);

        }
        [Fact]
        public void CheckTheFilePath()
        {
            //Arrange & Act
            var fileContents = "@Data/names.txt";
            //Assert
            Assert.NotNull(fileContents);
        }
        [Fact]
        public void SortInAssendingOrder()
        {

        }
            
   }

}

