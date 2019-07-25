using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;

namespace VinetkiBG.Services
{
    public class ViolationService : IViolationService
    {
        private readonly VinetkiBGDbContext db;

        public ViolationService(VinetkiBGDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Violation> GetAllViolationsForVehicle(string id)
        {
            return this.db.Violations
                .Where(x => x.VehicleId == id);
        }

        public Violation GetViolationById(string id)
        {
            var violationFromDb = this.db.Violations
                 .FirstOrDefault(x => x.Id == id);

            return violationFromDb;
        }

        public Violation RegisterViolation(string violationType, string Road, 
            DateTime violationDate, decimal penaltyAmount)
        {
            var violation = new Violation
            {
                ViolationType = violationType,
                Road = Road,
                ViolationDate = violationDate,
                PenaltyAmount = penaltyAmount
            };
            this.db.Violations.Add(violation);

            return violation;
        }
    }
}
