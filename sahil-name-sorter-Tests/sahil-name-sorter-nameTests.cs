﻿using SahilNameSorter.Domain;
using SahilNameSorterCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace sahilnamesorter.Tests
{
   public class PersonTests
    {
        private readonly IList<string> unsortedNames = new List<string>() { "Third Ceename", "First Aname", "Second Beename" };
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
        public void HasSortedNamesValues()
        {
            
        }

    }
}
