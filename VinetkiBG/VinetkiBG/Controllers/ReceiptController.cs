namespace VinetkiBG.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VinetkiBG.Models.ViewModels;
    using VinetkiBG.Services;
    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [Authorize]
        public IActionResult My(string id)
        {
            var receiptFromDb = this.receiptService
                .GetReceiptById(id);

            var model = AutoMapper.Mapper.Map<ReceiptMyViewModel>(receiptFromDb);
               
            return View(model);
        }
    }
}