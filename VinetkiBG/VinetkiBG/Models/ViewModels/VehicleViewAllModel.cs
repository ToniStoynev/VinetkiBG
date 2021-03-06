﻿namespace VinetkiBG.Models.ViewModels
{
    using VinetkiBG.Models.ServiceModels;
    using VinetkiBG.Services.Mapping;

    public class VehicleViewAllModel : IMapFrom<VehicleServiceModel>
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }

        public string Country { get; set; }

        public string PlateNumber { get; set; }

        public string ViolationId { get; set; }

        public string VignetteId { get; set; }
    }
}
