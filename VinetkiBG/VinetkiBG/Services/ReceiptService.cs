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
            var receipt = new Receipt
            {
                LicensePlate = receiptServiceModel.LicensePlate,
                VehicleType = receiptServiceModel.VehicleType,
                StartDate = receiptServiceModel.StartDate,
                EndDate = receiptServiceModel.EndDate,
                Price = receiptServiceModel.Price,
                VignetteId = receiptServiceModel.VignetteId
            };

            this.db.Receipts.Add(receipt);

            this.db.SaveChanges();

            return receipt.Id;
        }

        public ReceiptServiceModel GetReceiptById(string id)
        {
            var receiptFromDb = this.db.Receipts
                .SingleOrDefault(x => x.Id == id);

            var receiptServiceModel = new ReceiptServiceModel
            {
                Id = receiptFromDb.Id,
                LicensePlate = receiptFromDb.LicensePlate,
                VehicleType = receiptFromDb.VehicleType,
                StartDate = receiptFromDb.StartDate,
                EndDate = receiptFromDb.EndDate,
                Price = receiptFromDb.Price,
                VignetteId = receiptFromDb.VignetteId
            };

            return receiptServiceModel;
        }
    }
}
