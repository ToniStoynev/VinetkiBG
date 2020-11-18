namespace VinetkiBG.Models.ServiceModels
{
    using System;
    using VinetkiBG.Domain;
    using VinetkiBG.Services.Mapping;
    public class ReceiptServiceModel : IMapFrom<Receipt>, IMapTo<Receipt>
    {
        public string Id { get; set; }

        public string LicensePlate { get; set; }

        public string VehicleType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
        public string VignetteId { get; set; }

    }
}
