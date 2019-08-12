using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Models.ViewModels;
using VinetkiBG.Services;
using VinetkiBG.Tests.Common;
using Xunit;
using VinetkiBG.Services.Mapping;

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
                    Id = "jghjgjgh",
                    Brand = "Volkswagen",
                    Country = "France",
                    PlateNumber = "PS123KL",
                    OwnerId = "jgjhjh",
                    Type = "LightVehicle"
                } ,
                new Vehicle
                {
                    Id = "ljkl",
                    Brand = "Audi",
                    Country = "Belgium",
                    PlateNumber = "BG768KM",
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
            SeedData(context);
            this.vehicleService = new VehicleService(context);
           

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

        [Fact]
        public void Create_WithExistingLicensePlate_ShouldReturnFalse()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();

            this.vehicleService = new VehicleService(context);
            SeedData(context);

            VehicleServiceModel testVehicle = new VehicleServiceModel
            {
                Brand = "Audi",
                Country = "Bulgaria",
                PlateNumber = "fdsfsfs",
                Type = "Bus",
                OwnerId = "fsgsfg"
            };

            bool actualResult = this.vehicleService.CreateVehicle(testVehicle);
            Assert.Equal<bool>(actualResult, false);
        }

        [Fact]
        public void GetAll_WithExistingId_ShouldReturnAllVehiclesByGivenUserId()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();

            this.vehicleService = new VehicleService(context);
            SeedData(context);

            List<VehicleViewAllModel> actualResult = this.vehicleService.GetAll("jgjhjh").ToList();
            List<VehicleViewAllModel> expectedResult = new List<VehicleViewAllModel>()
            {
                new VehicleViewAllModel
                {
                    Id = "fddfsd",
                    Brand = "BWM",
                    Country = "Germany",
                    PlateNumber = "fdsfsfs",
                    Type = "LightVehicle"
                } ,
                new VehicleViewAllModel
                {
                    Id = "jghjgjgh",
                    Brand = "Volkswagen",
                    Country = "France",
                    PlateNumber = "PS123KL",
                    Type = "LightVehicle"
                } ,
                new VehicleViewAllModel
                {
                    Id = "ljkl",
                    Brand = "Audi",
                    Country = "Belgium",
                    PlateNumber = "BG768KM",
                    Type = "LightVehicle"
                }    
            };

            for (int i = 0; i < expectedResult.Count; i++)
            {
                var expectedEntry = expectedResult[i];
                var actualEntry = actualResult[i];

                Assert.True(expectedEntry.Brand == actualEntry.Brand);
                Assert.True(expectedEntry.Country == actualEntry.Country);
                Assert.True(expectedEntry.PlateNumber == actualEntry.PlateNumber);
                Assert.True(expectedEntry.Type == actualEntry.Type);
            }
        }

        [Fact]
        public void GetAll_WithNonExistingId_ShouldReturnEmptyCollection()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();

            this.vehicleService = new VehicleService(context);
            SeedData(context);

            List<VehicleViewAllModel> actualResult = this.vehicleService.GetAll("abch").ToList();
            Assert.Equal(actualResult.Count, 0);
        }

        [Fact]
        public void GetAll_ToUserWithNoVehicles_ShouldReturnEmptyCollection()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();

            this.vehicleService = new VehicleService(context);
            SeedData(context);

            List<VehicleViewAllModel> actualResult = this.vehicleService.GetAll("abcd").ToList();
            Assert.Equal(actualResult.Count, 0);
        }

        [Fact]
        public void GetVehicleByCountryAndLicensePlate_WithCorrectData_ShouldWorkCorrectly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.vehicleService = new VehicleService(context);

            var checkVehicle = new CheckVehicleServiceModel
            {
                Country = "Germany",
                LicensePlate = "fdsfsfs"
            };

            var actualResult = this.vehicleService.GetVechileByCountryAndLicensePlate(checkVehicle);
            var expectedResult = AutoMapper.Mapper.Map<VehicleServiceModel>(GetDummyVehicles()[0]);

            Assert.True(actualResult.Brand == expectedResult.Brand, "Brand is not returned properly!");
            Assert.True(actualResult.Country == expectedResult.Country, "Country is not returned properly!");
            Assert.True(actualResult.PlateNumber == expectedResult.PlateNumber, "Plate number is not returned properly!");
            Assert.True(actualResult.OwnerId == expectedResult.OwnerId, "Owner Id is not returned properly!");
            Assert.True(actualResult.ViolationId == expectedResult.ViolationId, "Violation Id is not returned properly!");
        }

        [Fact]
        public void GetVehicleByCountryAndLicensePlate_IfSuchVehicleDoesntExist_ShouldReturnNull()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.vehicleService = new VehicleService(context);

            var checkVehicle = new CheckVehicleServiceModel
            {
                Country = "Italy",
                LicensePlate = "IT124143"
            };

            var actualResult = this.vehicleService.GetVechileByCountryAndLicensePlate(checkVehicle);
            Assert.True(actualResult == null);
        }

        [Fact]
        public void GetVehicleById_WithCorrectId_ShouldWorkProperly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.vehicleService = new VehicleService(context);

            var actualResult = this.vehicleService.GetVechileById("ljkl");
            var expectedResult = AutoMapper.Mapper.Map<VehicleServiceModel>(GetDummyVehicles()[2]);

            Assert.True(actualResult.Brand == expectedResult.Brand, "Brand is not returned properly!");
            Assert.True(actualResult.Country == expectedResult.Country, "Country is not returned properly!");
            Assert.True(actualResult.Type == expectedResult.Type, "Type is not returned properly!");
            Assert.True(actualResult.PlateNumber == expectedResult.PlateNumber, "Plate number is not returned properly!");
            Assert.True(actualResult.OwnerId == expectedResult.OwnerId, "Owner Id is not returned properly!");
            Assert.True(actualResult.ViolationId == expectedResult.ViolationId, "Violation Id is not returned properly!");
        }
    }
}
