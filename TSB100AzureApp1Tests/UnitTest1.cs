using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TSB100AzureApp1.UserProfileServiceReference;
using TSB100AzureApp1.Logic;

namespace TSB100AzureApp1Tests
{
    [TestClass]
    public class UserStatisticsTests
    {
        [TestMethod]
        public void TestEmptyList_EmptyDictionary()
        {
            // Arrange
            var expected = 0;
            var input = new List<User>();
            var stats = new UserStatistics();

            // Act
            var actual = stats.GetUserCityStats(input);

            // Assert
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestOneCity()
        {
            // Arrange
            var expected = 1;
            var input = new List<User>
            {
                new User{City = "Trollhättan"}
            };
            var stats = new UserStatistics();

            // Act
            var actual = stats.GetUserCityStats(input);

            // Assert
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestTwoUsersSameCity()
        {
            // Arrange
            var expected = 1;
            var input = new List<User>
            {
                new User{City = "Trollhättan"},
                new User{City = "Trollhättan"}
            };
            var stats = new UserStatistics();

            // Act
            var actual = stats.GetUserCityStats(input);

            // Assert
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestTwoUsersDifferentCities()
        {
            // Arrange
            var expected = 2;
            var input = new List<User>
            {
                new User{City = "Trollhättan"},
                new User{City = "Vänersborg"}
            };
            var stats = new UserStatistics();

            // Act
            var actual = stats.GetUserCityStats(input);

            // Assert
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestTwoUsersOneCityNull()
        {
            // Arrange
            var expected = 2;
            var input = new List<User>
            {
                new User{City = "Trollhättan"},
                new User()
            };
            var stats = new UserStatistics();

            // Act
            var actual = stats.GetUserCityStats(input);

            // Assert
            Assert.AreEqual(expected, actual.Count);
        }
    }
}
