using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Services;
using VinetkiBG.Tests.Common;
using Xunit;

namespace VinetkiBG.Tests.Service
{
    public class ReceiptServiceTests
    {
        private IReceiptService receiptService;

        public ReceiptServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void CreateReceipt_WithCorrectData_ShouldWorkProperly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            this.receiptService = new ReceiptService(context);

            ReceiptServiceModel receiptServiceModel = new ReceiptServiceModel
            {
                LicensePlate = "fsdjfd",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(30),
                Price = 30,
                VehicleType = "Bus",
                VignetteId = "fsfs"
            };

            string actualResult = this.receiptService.CreateReceipt(receiptServiceModel);

            Assert.True(actualResult != null, "CreateRecipiet() doesn't work properly !");
        }

        [Fact]
        public void GetReceiptById_WithCorrectData_ShouldWorkProperly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            this.receiptService = new ReceiptService(context);

            #region Dummy Data
            context.Receipts.Add(new Receipt
            {
                Id = "abcd",
                LicensePlate = "KH4934BA",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(30),
                Price = 15,
                VignetteId = "fsdfs",
                VehicleType = "Bus"
            });

            context.SaveChanges();
            #endregion

            var receiptFromDb = context.Receipts.First();

            var exectedResult = AutoMapper.Mapper.Map<ReceiptServiceModel>(receiptFromDb);

            string testId = context.Receipts.First().Id;

            var actualResult = this.receiptService.GetReceiptById(testId);

            Assert.True(exectedResult.Id == actualResult.Id, "Id is not returned properly !");
            Assert.True(exectedResult.LicensePlate == actualResult.LicensePlate, "License Plate is not returned properly !");
            Assert.True(exectedResult.Price == actualResult.Price, "Price is not returned properly !");
            Assert.True(exectedResult.StartDate == actualResult.StartDate, "Start Date is not returned properly !");
            Assert.True(exectedResult.EndDate == actualResult.EndDate, "End date is not returned properly !");
            Assert.True(exectedResult.VignetteId == actualResult.VignetteId, "Vignette Id is not returned properly !");
            Assert.True(exectedResult.VehicleType == actualResult.VehicleType, "Vehicle Type is not returned properly !");
        }
    }
}
