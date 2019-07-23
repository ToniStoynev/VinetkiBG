using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;

namespace VinetkiBG.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly VinetkiBGDbContext db;

        public ReceiptService(VinetkiBGDbContext db)
        {
            this.db = db;
        }

        public Receipt CreateReceipt(Receipt receipt)
        {
            this.db.Receipts.Add(receipt);
            this.db.SaveChanges();

            return receipt;
        }

        public Receipt GetReceiptById(string id)
        {
            var receipt = this.db.Receipts.Where(x => x.Id == id).FirstOrDefault();

            return receipt;
        }
    }
}
