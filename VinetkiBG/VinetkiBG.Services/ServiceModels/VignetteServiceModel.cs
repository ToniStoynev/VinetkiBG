namespace VinetkiBG.Models.ServiceModels
{
    using System;
    using VinetkiBG.Domain;
    using VinetkiBG.Services.Mapping;
    public class VignetteServiceModel : IMapFrom<Vignette>, IMapTo<Vignette>
    {
        public string Id { get; set; }
        public string Category { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string VehicleId { get; set; }

        public string ReceiptId { get; set; }

        public string VehicleType { get; set; }
    }
}
