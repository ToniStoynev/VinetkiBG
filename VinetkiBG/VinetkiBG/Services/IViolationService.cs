using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ServiceModels;

namespace VinetkiBG.Services
{
    public interface IViolationService
    {
        string RegisterViolation(ViolationServiceModel violationServiceModel);

        ViolationServiceModel GetViolationById(string id);
      
    }
}
