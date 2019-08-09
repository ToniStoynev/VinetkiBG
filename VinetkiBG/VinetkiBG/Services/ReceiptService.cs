using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;

namespace VinetkiBG.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly VinetkiBGDbContext db;

        public ReceiptService(VinetkiBGDbContext db)
        {
            this.db = db;
        }

        public string CreateReceipt(ReceiptServiceModel receiptServiceModel)
        {
            var receipt = AutoMapper.Mapper.Map<Receipt>(receiptServiceModel);

            this.db.Receipts.Add(receipt);

            this.db.SaveChanges();

            return receipt.Id;
        }

        public ReceiptServiceModel GetReceiptById(string id)
        {
            var receiptFromDb = this.db.Receipts
                .SingleOrDefault(x => x.Id == id);

            var receiptServiceModel = AutoMapper.Mapper.Map<ReceiptServiceModel>(receiptFromDb);
           
            return receiptServiceModel;
        }
    }
}
