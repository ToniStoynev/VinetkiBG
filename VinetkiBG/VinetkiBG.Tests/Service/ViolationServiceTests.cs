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
    public class ViolationServiceTests
    {
        public IViolationService violationService;

        private List<Violation> GetDummyViolations()
        {
            return new List<Violation>()
            {
                new Violation
                {
                    Id = "hogfdg",
                    PenaltyAmount = 100,
                    Road = "E-79",
                    VehicleId = "fsdfsd",
                    ViolationDate = DateTime.UtcNow,
                    ViolationType = "Compensatory Charge"
                },
                new Violation
                {
                    Id = "hgfhfgh",
                    PenaltyAmount = 70,
                    Road = "I-I",
                    VehicleId = "nvvbnn",
                    ViolationDate = DateTime.UtcNow,
                    ViolationType = "Compensatory Charge"
                }
            };
        }

        private void SeedData(VinetkiBGDbContext context)
        {
            context.Violations.AddRange(GetDummyViolations());
            context.SaveChanges();
        }

        public ViolationServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void GetViolationById_WithExistingId_ShouldWorkProperly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.violationService = new ViolationService(context);

            var actualResult = this.violationService.GetViolationById("hogfdg");

            var expectedResult = AutoMapper.Mapper.Map<ViolationServiceModel>(GetDummyViolations()[0]);

            Assert.True(actualResult.Id == expectedResult.Id, "Id is not returned properly!");
            Assert.True(actualResult.PenaltyAmount == expectedResult.PenaltyAmount, "Penalty amount is not returned properly!");
            Assert.True(actualResult.Road == expectedResult.Road, "Road is not returned properly!");
            Assert.True(actualResult.VehicleId == expectedResult.VehicleId, "Vehicle Id is not returned properly!");
            Assert.True(actualResult.ViolationType == expectedResult.ViolationType, "Violation Type is not returned properly!");
        }

        [Fact]
        public void GetViolationById_WithNonExistingId_ShouldReturnNull()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.violationService = new ViolationService(context);

            var actualResult = this.violationService.GetViolationById("jhkk");

            Assert.True(actualResult == null);
        }

        [Fact]
        public void RegisterViolation_WithCorrectData_ShouldWorkProperly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            this.violationService = new ViolationService(context);

            #region DummyData
            context.VinetkiBGUsers.Add(new VinetkiBGUser
            {
                Id = "TonySt",
                UserName = "Tony"
            });
            context.SaveChanges();
            context.Vehicles.Add(new Vehicle
            {
                Id = "abcd",
                Brand = "BMW",
                Country = "Bulgaria",
                OwnerId = "TonySt",
                PlateNumber = "KH4934BA",
                Type = "Light Vehicle"           
            });
            context.SaveChanges();
            #endregion

            ViolationServiceModel violationServiceModel = new ViolationServiceModel
            {
                Id = "12345",
                PenaltyAmount = 100,
                Road = "I-6",
                VehicleId = "abcd",
                ViolationDate = DateTime.UtcNow,
                ViolationType = "Fine"
            };

            var actualResult = this.violationService.RegisterViolation(violationServiceModel);
            var expectedResult = "12345";

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void RegisterViolation_WithExistingUserOrVehicle_ShoulThrowNullReferenceException()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            this.violationService = new ViolationService(context);

            ViolationServiceModel violationServiceModel = new ViolationServiceModel
            {
                Id = "12345",
                PenaltyAmount = 100,
                Road = "I-6",
                VehicleId = "abcd",
                ViolationDate = DateTime.UtcNow,
                ViolationType = "Fine"
            };

            Assert.Throws<NullReferenceException>(() => this.violationService.RegisterViolation(violationServiceModel));
        }
    }
}
