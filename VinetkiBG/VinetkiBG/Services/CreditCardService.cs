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
        private readonly UserManager<VinetkiBGUser> manager;

        public CreditCardService(VinetkiBGDbContext db, UserManager<VinetkiBGUser> manager)
        {
            this.db = db;
            this.manager = manager;
        }
        public void AddCreditCard(string cardHolder, string cardNumber, string cvv, DateTime expirationDate)
        {
            var card = new CreditCard
            {
                CardHolderName = cardHolder,
                CreditCardNumber = cardNumber,
                CVV = cvv,
                ExpirationDate = expirationDate
            };

            this.db.CreditCards.Add(card);
            this.db.SaveChanges();
        }
    }
}
