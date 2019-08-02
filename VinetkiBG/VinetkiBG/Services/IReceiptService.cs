using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;

namespace VinetkiBG.Services
{
    public interface IReceiptService
    {
        string CreateReceipt(ReceiptServiceModel receiptServiceModel);

        ReceiptServiceModel GetReceiptById(string id);
    }
}
