namespace VinetkiBG.Services
{
    using System.Linq;
    using VinetkiBG.Data;
    using VinetkiBG.Domain;
    using VinetkiBG.Models.ServiceModels;

    public class ViolationService : IViolationService
    {
        private readonly VinetkiBGDbContext db;

        public ViolationService(VinetkiBGDbContext db)
        {
            this.db = db;
        }

        public ViolationServiceModel GetViolationById(string id)
        {
            var violationFromDb = this.db.Violations
                 .SingleOrDefault(x => x.Id == id);

            var violationServiceModel = AutoMapper.Mapper.Map<ViolationServiceModel>(violationFromDb);

            return violationServiceModel;
        }

        public string RegisterViolation(ViolationServiceModel violationServiceModel)
        {
            var violation = AutoMapper.Mapper.Map<Violation>(violationServiceModel);

            this.db.Violations.Add(violation);

            var vehicle = this.db.Vehicles
                .FirstOrDefault(x => x.Id == violationServiceModel.VehicleId);

            vehicle.ViolationId = violation.Id;

            this.db.SaveChanges();

            return violation.Id;
        }


    }
}
