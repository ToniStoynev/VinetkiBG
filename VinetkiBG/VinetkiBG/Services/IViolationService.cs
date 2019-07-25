using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;

namespace VinetkiBG.Services
{
    public interface IViolationService
    {
        Violation RegisterViolation(string violationType, string Road,
            DateTime violationDate, decimal penaltyAmount);

        Violation GetViolationById(string id);

        IQueryable<Violation> GetAllViolationsForVehicle(string id);
    }
}
