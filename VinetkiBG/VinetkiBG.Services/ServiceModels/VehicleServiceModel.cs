namespace VinetkiBG.Models.ServiceModels
{
    using VinetkiBG.Domain;
    using VinetkiBG.Services.Mapping;

    public class VehicleServiceModel : IMapFrom<Vehicle>, IMapTo<Vehicle>
    {
        public string Id { get; set; }
        public string Brand { get; set; }

        public string Type { get; set; }

        public string Country { get; set; }

        public string PlateNumber { get; set; }

        public string OwnerId { get; set; }

        public string ViolationId { get; set; }
    }
}
