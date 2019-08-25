using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Services;
using VinetkiBG.Tests.Common;
using Xunit;

namespace VinetkiBG.Tests.Service
{
    public class UserServiceTests
    {
        private IUserService userService;

        private List<VinetkiBGUser> GetDummyUsers()
        {
            return new List<VinetkiBGUser>
            {
                new VinetkiBGUser
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    UserName = "Ivan",
                },
                new VinetkiBGUser
                {
                    FirstName = "Petkan",
                    LastName = "Petkanov",
                    UserName = "Petkan",
                }
            };

        }

        private List<Vehicle> GetDummyVehicles()
        {
            return new List<Vehicle>
            {
                new Vehicle
                {
                    Brand = "BMW",
                    Country = "Bulgaria",
                    PlateNumber = "KH4934BA",
                    OwnerId = GetDummyUsers()[0].Id
                },
                new Vehicle
                {
                    Brand = "Mercedes",
                    Country = "Bulgaria",
                    PlateNumber = "KH7678BP",
                    OwnerId = GetDummyUsers()[0].Id
                }
            };
        }

        private void SeedData(VinetkiBGDbContext context)
        {
            context.AddRange(GetDummyUsers());
            context.AddRange(GetDummyVehicles());
            context.SaveChanges();
        }

        public UserServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void GetUserById_WithExistingId_ShouldReturnUserCorreclty()
        {
            string errorMessagePostFix = " is not returned correctly";

            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.userService = new UserService(context);

            string testId = context.Users.First().Id;

            var actualtResult = this.userService.GetUserById(testId);
            var expectedResult = context.Users.First();

            Assert.True(actualtResult.Id == expectedResult.Id, "Id" + errorMessagePostFix);
            Assert.True(actualtResult.FirstName == expectedResult.FirstName, "First Name" + errorMessagePostFix);
            Assert.True(actualtResult.LastName == expectedResult.LastName, "Last Name" + errorMessagePostFix);
            Assert.True(actualtResult.Vehicles.Count == expectedResult.Vehicles.Count, "Vehicles count" + errorMessagePostFix);
        }

        [Fact]
        public void GetUserById_WithNonExistingId_ShouldReturnNull()
        {
            string errorMessage = "GetUserById() doesn't work properly";

            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.userService = new UserService(context);

            string testId = "fsd";
            var actualResult = this.userService.GetUserById(testId);

            Assert.True(actualResult == null, errorMessage);
        }

        [Fact]
        public void GetVehicleCountByUserId_WithExistingId_ShouldWorkProperly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.userService = new UserService(context);

            string testId = GetDummyUsers()[0].Id;

            var actualResult = this.userService.GetVehicleCountByUserId(testId);
            var expectedResult = context.Vehicles
                .Where(x => x.OwnerId == testId)
                .Count();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetVehicleCountByUserId_WithNonExistingId_ShouldReturnZero()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.userService = new UserService(context);

            string testId = "fsd";
            int actualResult = this.userService.GetVehicleCountByUserId(testId);
            int expectedResult = 0;

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
