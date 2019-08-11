using System;
using System.Collections.Generic;
using System.Text;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Services;
using VinetkiBG.Tests.Common;
using Xunit;

namespace VinetkiBG.Tests.Service
{
    public class VehicleServiceTests
    {
        private IVehicleService vehicleService;

        private List<VinetkiBGUser> GetDummyUsers()
        {
            return new List<VinetkiBGUser>()
            {
                new VinetkiBGUser
                {
                    Id ="abcd",
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Email = "ivan@abv.bg",
                    UserName = "Ivan"
                },
                new VinetkiBGUser
                {
                    Id ="fsgsfg",
                    FirstName = "Stoqn",
                    LastName = "Stoqnov",
                    Email = "stoqn@abv.bg",
                    UserName = "Stoqn"
                },
                new VinetkiBGUser
                {
                    Id ="jgjhjh",
                    FirstName = "Dragan",
                    LastName = "Draganov",
                    Email = "dragan@abv.bg",
                    UserName = "Dragan"
                },
            };
        }

        private List<Vehicle> GetDummyVehicles()
        {
            return new List<Vehicle>()
            {
                new Vehicle
                {
                    Id = "fddfsd",
                    Brand = "BWM",
                    Country = "Germany",
                    PlateNumber = "fdsfsfs",
                    OwnerId = "jgjhjh",
                    Type = "LightVehicle"
                } ,
                new Vehicle
                {
                    Id = "kjhkhkj",
                    Brand = "Mercedes",
                    Country = "Germany",
                    PlateNumber = "jhhfgdg",
                    OwnerId = "fsgsfg",
                    Type = "Bus"
                }
            };
        }

        private void SeedData(VinetkiBGDbContext context)
        {
            context.AddRange(GetDummyUsers());
            context.AddRange(GetDummyVehicles());
            context.SaveChanges();
        }
        public VehicleServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void Create_WithCorrectData_ShouldSuccesfullyCreate()
        {
            string errorMessagePrefix = "VehicleService Create() method does not work properly.";

            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();

            this.vehicleService = new VehicleService(context);
            SeedData(context);

            VehicleServiceModel testVehicle = new VehicleServiceModel
            {
                Brand = "Audi",
                Country = "Bulgaria",
                PlateNumber = "CB5489KP",
                Type = "Bus",
                OwnerId = "fsgsfg"
            };

            bool actualResult = this.vehicleService.CreateVehicle(testVehicle);
            Assert.True(actualResult, errorMessagePrefix);
        }
    }
}
