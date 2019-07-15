using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Services
{
    public interface ICreditCardService
    {
        void AddCreditCard(string cardHolder, string cardNumber, string cvv, 
            DateTime expirationDate, string userId);
    }
}
