namespace VinetkiBG.Services
{
    using VinetkiBG.Models.ServiceModels;
    using VinetkiBG.Services.Common;

    public interface IVignneteService : IService
    {
        string BuyVignette(VignetteServiceModel vignetteServiceModel);

        VignetteServiceModel CheckVignette(CheckVehicleServiceModel checkVehicleServiceModel);

        VignetteServiceModel GetVignetteById(string id);

    }
}
