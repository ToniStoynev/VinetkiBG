using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ServiceModels;

namespace VinetkiBG.Services
{
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

            var violationServiceModel = new ViolationServiceModel
            {
                Id = violationFromDb.Id,
                ViolationType = violationFromDb.ViolationType,
                Road = violationFromDb.Road,
                PenaltyAmount = violationFromDb.PenaltyAmount,
                ViolationDate = violationFromDb.ViolationDate,
                VehicleId = violationFromDb.VehicleId
            };

            return violationServiceModel;
        }

        public Violation RegisterViolation(ViolationServiceModel violationServiceModel)
        {
            var violation = AutoMapper.Mapper.Map<Violation>(violationServiceModel);

            this.db.Violations.Add(violation);

            var vehicle = this.db.Vehicles.FirstOrDefault(x => x.Id == violationServiceModel.VehicleId);

            vehicle.ViolationId = violation.Id;

            this.db.SaveChanges();

            return violation;
        }


    }
}
