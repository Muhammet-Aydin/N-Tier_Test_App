using Microsoft.AspNetCore.Mvc;
using N_Tier_App_Business.Abstract;
using N_Tier_Test_App.Models;
using N_Tier_Test_App_Entities;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace N_Tier_Test_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
           var getUsers=  _userService.GetAll();

         
            return View(getUsers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}