namespace VinetkiBG.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using VinetkiBG.Data;
    using VinetkiBG.Domain;
    public class UserService : IUserService
    {
        private readonly VinetkiBGDbContext db;

        public UserService(VinetkiBGDbContext db)
        {
            this.db = db;
        }
        public async Task<VinetkiBGUser> GetUserById(string id)
        {
            return await  this.db.Users
                                 .Include(x => x.Vehicles)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetVehicleCountByUserId(string id)
        {
            return await db.Users
                           .Where(x => x.Id == id)
                           .Select(x => x.Vehicles.Count())
                           .FirstOrDefaultAsync();
        }
    }
}
