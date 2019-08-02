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

        public Violation RegisterViolation(string violationType, string Road,
             DateTime violationDate, decimal penaltyAmount, string vehicleId)
        {
            var violation = new Violation
            {
                ViolationType = violationType,
                Road = Road,
                ViolationDate = violationDate,
                PenaltyAmount = penaltyAmount,
                VehicleId = vehicleId
            };

            this.db.Violations.Add(violation);

            var vehicle = this.db.Vechiles.FirstOrDefault(x => x.Id == vehicleId);

            vehicle.ViolationId = violation.Id;

            this.db.SaveChanges();

            return violation;
        }


    }
}
