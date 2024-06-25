using FlexiDev.Models;
using FlexiDev.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class CalculationServiceTests
    {
        private readonly CalculationService _calculationService;

        public CalculationServiceTests()
        {
            _calculationService = new CalculationService();
        }

        [Fact]
        public void AverageKills_ValidData_ReturnsCorrectAverage()
        {
            // Arrange
            var data = new List<Person>
            {
                new Person { Age = 10, YearOfDeath = 12 },
                new Person { Age = 13, YearOfDeath = 17 }
            };

            // Act
            double result = _calculationService.AverageKills(data);

            // Assert
            Assert.Equal(4.5, result);
        }

        [Fact]
        public void AverageKills_InvalidData_ReturnsMinusOne()
        {
            // Arrange
            var data = new List<Person>
            {
                new Person { Age = -5, YearOfDeath = 12 },
                new Person { Age = 13, YearOfDeath = 17 }
            };

            // Act
            double result = _calculationService.AverageKills(data);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void AverageKills_EmptyList_ReturnsMinusOne()
        {
            // Arrange
            var data = new List<Person>();

            // Act
            double result = _calculationService.AverageKills(data);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void AverageKills_BornBeforeWitchControl_ReturnsMinusOne()
        {
            // Arrange
            var data = new List<Person>
            {
                new Person { Age = 5, YearOfDeath = 4 }  // Born before witch control (year 4 - age 5 = year -1)
            };

            // Act
            double result = _calculationService.AverageKills(data);

            // Assert
            Assert.Equal(-1, result);
        }
    }
}
