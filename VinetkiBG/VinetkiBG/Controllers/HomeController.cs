namespace VinetkiBG.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using VinetkiBG.Models.ViewModels;
    using VinetkiBG.Services;

    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        { 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await userService.GetUserById(userId);

            int vehicleCount = await userService.GetVehicleCountByUserId(userId);

            var model = AutoMapper.Mapper.Map<UserViewModel>(user);

            return this.View(model);
        }
    }
}
