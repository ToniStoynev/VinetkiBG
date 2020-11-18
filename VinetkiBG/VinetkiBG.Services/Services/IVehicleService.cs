namespace VinetkiBG.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using VinetkiBG.Models.ServiceModels;
    using VinetkiBG.Services.Common;

    public interface IVehicleService : IService
    {
        Task<bool> CreateVehicle(VehicleServiceModel vehicleServiceModel);
        Task<bool> EditVehicle(VehicleServiceModel model);

        IQueryable<VehicleServiceModel> GetAll(string id);

        Task<VehicleServiceModel> GetVechileById(string id);

        Task<VehicleServiceModel> GetVechileByCountryAndLicensePlate(CheckVehicleServiceModel checkVehicleServiceModel);
    }
}
