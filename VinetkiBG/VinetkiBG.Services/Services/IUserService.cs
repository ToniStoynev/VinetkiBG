namespace VinetkiBG.Services
{
    using System.Threading.Tasks;
    using VinetkiBG.Domain;
    using VinetkiBG.Services.Common;

    public interface IUserService : IService
    {
        Task<VinetkiBGUser> GetUserById(string id);
        Task<int> GetVehicleCountByUserId(string id);
    }
}
