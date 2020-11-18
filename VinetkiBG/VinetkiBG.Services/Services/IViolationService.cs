namespace VinetkiBG.Services
{
    using VinetkiBG.Models.ServiceModels;
    using VinetkiBG.Services.Common;

    public interface IViolationService : IService
    {
        string RegisterViolation(ViolationServiceModel violationServiceModel);

        ViolationServiceModel GetViolationById(string id);
      
    }
}
