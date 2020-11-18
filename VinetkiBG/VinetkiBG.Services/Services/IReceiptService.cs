namespace VinetkiBG.Services
{
    using VinetkiBG.Models.ServiceModels;
    using VinetkiBG.Services.Common;
    public interface IReceiptService : IService
    {
        string CreateReceipt(ReceiptServiceModel receiptServiceModel);

        ReceiptServiceModel GetReceiptById(string id);
    }
}
