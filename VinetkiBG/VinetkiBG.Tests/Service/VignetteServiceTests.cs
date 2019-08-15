using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Services;
using VinetkiBG.Tests.Common;
using Xunit;

namespace VinetkiBG.Tests.Service
{
    public class VignetteServiceTests
    {
        private IVignneteService vignneteService;

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
                    Type = "LightVehicle",
                    VignetteId = null
                } ,
                new Vehicle
                {
                    Id = "jghjgjgh",
                    Brand = "Volkswagen",
                    Country = "France",
                    PlateNumber = "PS123KL",
                    OwnerId = "jgjhjh",
                    Type = "LightVehicle",
                    VignetteId = null
                } ,
                new Vehicle
                {
                    Id = "ljkl",
                    Brand = "Audi",
                    Country = "Belgium",
                    PlateNumber = "BG768KM",
                    OwnerId = "jgjhjh",
                    Type = "LightVehicle",
                    VignetteId = null
                } ,
                new Vehicle
                {
                    Id = "kjhkhkj",
                    Brand = "Mercedes",
                    Country = "Germany",
                    PlateNumber = "jhhfgdg",
                    OwnerId = "fsgsfg",
                    Type = "Bus",
                    VignetteId = null
                }
            };
        }

        private void SeedData(VinetkiBGDbContext context)
        {
            context.AddRange(GetDummyVehicles());
            context.SaveChanges();
        }

        public VignetteServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void BuyVignette_WithCorrectData_ShouldSuccessfullyBuyVignette()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.vignneteService = new VignetteService(context);

            VignetteServiceModel vignetteServiceModel = new VignetteServiceModel
            {
                Category = "Weekly",
                Price = 80,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7),
                VehicleType = "Bus",
                VehicleId = GetDummyVehicles()[1].Id
            };

            var actualResult = this.vignneteService.BuyVignette(vignetteServiceModel);

            var expectedResult = context.Vehicles
                .SingleOrDefault(x => x.Id == vignetteServiceModel.VehicleId)
                .VignetteId;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CheckVignette_WithCorrectData_ShouldWorkProperly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.vignneteService = new VignetteService(context);

            VignetteServiceModel vignetteServiceModel = new VignetteServiceModel
            {
                Category = "Weekly",
                Price = 80,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7),
                VehicleType = "Bus",
                VehicleId = GetDummyVehicles()[1].Id
            };

            vignneteService.BuyVignette(vignetteServiceModel);

            CheckVehicleServiceModel checkVehicleServiceModel = new CheckVehicleServiceModel
            {
                Country = "France",
                LicensePlate = "PS123KL"
            };

            var actualResult = this.vignneteService.CheckVignette(checkVehicleServiceModel);

            var vignetteFromDb = context.Vignettes
                .SingleOrDefault(x => x.VehicleId == GetDummyVehicles()[1].Id);

            var expectedResult = AutoMapper.Mapper.Map<VignetteServiceModel>(vignetteFromDb);

            Assert.True(actualResult.Id == expectedResult.Id, "Id is not returned properly !");
            Assert.True(actualResult.Price == expectedResult.Price, "Price is not returned properly !");
            Assert.True(actualResult.StartDate == expectedResult.StartDate, "Star Date is not returned properly !");
            Assert.True(actualResult.EndDate == expectedResult.EndDate, "End date is not returned properly !");
            Assert.True(actualResult.Category == expectedResult.Category, "Category is not returned properly !");
            Assert.True(actualResult.VehicleType == expectedResult.VehicleType, "Vehicle Type is not returned properly !");
        }

        [Fact]
        void CheckVignette_WithNonExistingVehicle_ShouldReturnNull()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.vignneteService = new VignetteService(context);

            CheckVehicleServiceModel checkVehicleServiceModel = new CheckVehicleServiceModel
            {
                Country = "Albania",
                LicensePlate = "5435gdfgdf"
            };

            var actualResult = this.vignneteService.CheckVignette(checkVehicleServiceModel);

            Assert.True(actualResult == null);
        }

        [Fact]
        public void CheckVignette_WithVehicleWithoutVignette_ShouldReturnNull()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.vignneteService = new VignetteService(context);

            CheckVehicleServiceModel checkVehicleServiceModel = new CheckVehicleServiceModel
            {
                Country = "Belgium",
                LicensePlate = "BG768KM"
            };

            var isVehicleExist = context.Vehicles
                .FirstOrDefault(x => x.PlateNumber == "BG768KM");

            var actualResult = this.vignneteService.CheckVignette(checkVehicleServiceModel);

            Assert.True(isVehicleExist != null);
            Assert.True(actualResult == null);
        }

        [Fact]
        public void GetVignetteById_WithExistingId_ShouldWorkProperly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();

            #region Dummy Data

            context.Vehicles.Add(new Vehicle
            {
                Id = "jghjgjgh",
                Brand = "Volkswagen",
                Country = "France",
                PlateNumber = "PS123KL",
                OwnerId = "jgjhjh",
                Type = "LightVehicle"
            });

            context.SaveChanges();
            context.Vignettes.Add(new Vignette
            {
                Price = 15,
                Category = "Weekly",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7),
                VehicleId = "jghjgjgh",
            });
            context.Vignettes.Add(new Vignette());
            context.Vignettes.Add(new Vignette());

            context.SaveChanges();
            #endregion
            this.vignneteService = new VignetteService(context);

            string testId = context.Vignettes.First().Id;
            var vignetteFromDb = context.Vignettes.First();

            var actualResult = this.vignneteService.GetVignetteById(testId);
            var expectedResult = AutoMapper.Mapper.Map<VignetteServiceModel>(vignetteFromDb);

            Assert.True(actualResult.Id == expectedResult.Id, "Id is not returned properly !");
            Assert.True(actualResult.Price == expectedResult.Price, "Price is not returned properly !");
            Assert.True(actualResult.StartDate == expectedResult.StartDate, "Start Date is not returned properly !");

        }
    }
}
