namespace VinetkiBG.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using VinetkiBG.Domain;
    using VinetkiBG.Models.ViewModels;
    using VinetkiBG.Services;

    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<VinetkiBGUser> manager;

        public HomeController(IUserService userService, UserManager<VinetkiBGUser> manager)
        {
            this.userService = userService;
            this.manager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var id = manager.GetUserId(this.User);

            var user = userService.GetUserById(id);

            int vehicleCount = await userService.GetVehicleCountByUserId(id);

            var model = AutoMapper.Mapper.Map<UserViewModel>(user);

            return this.View(model);
        }


    }
}
