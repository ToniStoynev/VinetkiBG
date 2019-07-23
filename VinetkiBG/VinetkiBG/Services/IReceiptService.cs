using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;

namespace VinetkiBG.Services
{
    public interface IReceiptService
    {
        Receipt CreateReceipt(Receipt receipt);

        Receipt GetReceiptById(string id);
    }
}
