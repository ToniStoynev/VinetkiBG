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

namespace VinetkiBG.Tests.Service
{
    public class CreditCardServiceTests
    {
        private ICreditCardService creditCardService;

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

        private List<CredtiCard> GetDummyCreditCards()
        {
            return new List<CredtiCard>()
            {
                new CredtiCard
                {
                    BankName = "DSK",
                    BIC = " HFSDFS425",
                    IBAN = "FDSFSF",
                    TotalAmount = 1200,
                    CardHolderId = "jgjhjh"
                },
                new CredtiCard
                {
                     BankName = "Raifaizen",
                     BIC = " JGDFGF",
                     IBAN = "KLPOU",
                     TotalAmount = 5600,
                     CardHolderId = "jgjhjh"
                }
            };
        }

        private List<Vehicle> GetDummyVehicles()
        {
            return new List<Vehicle>()
            {
                new Vehicle
                {
                    Id = "abcd",
                    Brand = "BMW",
                    Country = "Bulgaria",
                    PlateNumber = "KH4934BA",
                    OwnerId = "abcd",
                    Type = "LightVehicle"
                },
                new Vehicle
                {
                    Id = "dfgh",
                    Brand = "Mercedes",
                    Country = "Bulgaria",
                    PlateNumber = "KH9735BP",
                    OwnerId = "abcd",
                    Type = "LightVehicle",
                    ViolationId = "afsdfsd"
                }
            };
        }

        private List<Violation> GetDummyViolations()
        {
            return new List<Violation>()
            {
                new Violation
                {
                    Id = "afsdfsd",
                    ViolationType = "Fine",
                    Road = "E89",
                    PenaltyAmount = 100,
                    ViolationDate = DateTime.UtcNow,
                    VehicleId = "dfgh"
                }
            };
        }

        private void SeedData(VinetkiBGDbContext context)
        {
            context.AddRange(GetDummyUsers());
            context.AddRange(GetDummyCreditCards());
            context.AddRange(GetDummyVehicles());
            context.AddRange(GetDummyViolations());
            context.SaveChanges();
        }
        public CreditCardServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void Register_WithCorrectData_ShouldWorkProperly()
        {
            string errorMessage = "Register method does not work properly !";

            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();

            this.creditCardService = new CreditCardService(context);

            CreditCardServiceModel creditCardServiceModel = new CreditCardServiceModel
            {
                BankName = "DSK",
                IBAN = "GB24OK475",
                BIC = "HKMB497",
                TotalAmount = 1000,
                CardHolderId = "fsgsfg"
            };

            var actualResult = this.creditCardService.Register(creditCardServiceModel);
            Assert.True(actualResult == true, errorMessage);
        }

        [Fact]
        public void GetCreditCardById_WithExistingId_ShouldWorkProperly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.creditCardService = new CreditCardService(context);

            #region DummyData

            context.CreditCards.Add(new CredtiCard
            {
                BankName = "DSK",
                BIC = " HFSDFS425",
                IBAN = "FDSFSF",
                TotalAmount = 1200,
                CardHolderId = "jgjhjh"
            });
            context.SaveChanges();
            #endregion

            var creditCardFromDb = context.CreditCards.First();

            var expectedResult = AutoMapper.Mapper.Map<CreditCardAllViewModel>(creditCardFromDb);

            var actualResult = this.creditCardService.GetCreditCardById(expectedResult.Id);

            Assert.True(actualResult.BankName == expectedResult.BankName, "Bank name is not returned properly");
            Assert.True(actualResult.IBAN == expectedResult.IBAN, "IBAN name is not returned properly");
            Assert.True(actualResult.TotalAmount == expectedResult.TotalAmount, "Total amount name is not returned properly");
        }

        [Fact]
        public void GetCreditCard_WithNonExistingId_ShouldReturnNull()
        {
            string errorMessage = "GetCreditCardById () doesn't work correctly";
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.creditCardService = new CreditCardService(context);

            var actualResult = this.creditCardService.GetCreditCardById("prakash");

            Assert.True(actualResult == null, errorMessage);
        }

        [Fact]
        public void GetAllCards_WithCorrectData_ShouldWorkProperly()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.creditCardService = new CreditCardService(context);

            string testId = GetDummyUsers()[2].Id;

            var actualResult = this.creditCardService.GetAllCards(testId).ToList();
            var expectedResult = new List<CreditCardAllViewModel>
            {
                new CreditCardAllViewModel
                {
                     BankName = "DSK",
                    BIC = " HFSDFS425",
                    IBAN = "FDSFSF",
                    TotalAmount = 1200,
                },
                new CreditCardAllViewModel
                {
                     BankName = "Raifaizen",
                     BIC = " JGDFGF",
                     IBAN = "KLPOU",
                     TotalAmount = 5600,
                }
            };

            for (int i = 0; i < expectedResult.Count; i++)
            {
                var expectedEntry = expectedResult[i];
                var actualEntry = actualResult[i];

                Assert.True(expectedEntry.BankName == actualEntry.BankName, "Bank Name is not returned properly");
                Assert.True(expectedEntry.IBAN == actualEntry.IBAN, "IBAN is not returned properly");
                Assert.True(expectedEntry.BIC == actualEntry.BIC, "BIC Name is not returned properly");
                Assert.True(expectedEntry.TotalAmount == actualEntry.TotalAmount, "TotalAmount is not returned properly");
            }
        }

        [Fact]
        public void GetAllCards_ToUserWithNoCards_ShoulReturnEmptyCollection()
        {
            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.creditCardService = new CreditCardService(context);

            string testId = GetDummyUsers()[0].Id;

            var actualResult = this.creditCardService.GetAllCards(testId).ToList();
            Assert.True(actualResult.Count == 0, "GetAllCards doesn't work proplerly");
        }

        [Fact]
        public void DeleteViolation_WithExistingId_ShouldWorkProperly()
        {
            string errorMessage = "DeleteViolation() method doesn't work properly";

            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.creditCardService = new CreditCardService(context);

            string testId = GetDummyViolations()[0].Id;

            var expectedResult = this.creditCardService.DeleteViolation(testId);
            Assert.True(expectedResult == true, errorMessage);
        }

        [Fact]
        public void PayPenalty_WithCorrectData_ShouldWorkProperly()
        {
            string errorMessage = "PayPenalty() doesn't work properly";
            decimal testAmount = 100;

            var context = VinetkiBGDbContextInMemoryFactory.InitializeContext();
            SeedData(context);
            this.creditCardService = new CreditCardService(context);

            string testId = context.CreditCards.First().Id;

            decimal startAmount = context.CreditCards.First().TotalAmount; 

            var expectedResult = this.creditCardService.PayPenalty(testId, testAmount);

            decimal expectedAmountAfterPaidPenalty = GetDummyCreditCards()[0].TotalAmount - testAmount;
            decimal actualAmountAfterPaidPenalty = context.CreditCards.First().TotalAmount;

            Assert.Equal(expectedAmountAfterPaidPenalty, actualAmountAfterPaidPenalty);
            Assert.True(expectedResult == true, errorMessage);
        }
    }
}
