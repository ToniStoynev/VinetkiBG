using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;

namespace VinetkiBG.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly VinetkiBGDbContext db;


        public CreditCardService(VinetkiBGDbContext db)
        {
            this.db = db;
        }
        public void AddCreditCard(string cardHolder, string cardNumber, string cvv,
            DateTime expirationDate, string userId)
        {
            var card = new CreditCard
            {
                CardHolderName = cardHolder,
                CreditCardNumber = cardNumber,
                CVV = cvv,
                ExpirationDate = expirationDate,
                UserId = userId

            };

            this.db.CreditCards.Add(card);
            this.db.SaveChanges();
        }
    }
}
