using APCM.Models;
using APCM.Models.Home;
using APCM.Services.HomeService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace APCM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _homeService = homeService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            int recent = 10;
            int largest = 5;
            var data = new HomeViewModel()
            {
                RecentCollections = (await _homeService.RecentCollections(recent)).Data,
                LargestCollections=(await _homeService.LargestCollections(largest)).Data,
            };
            return View(data);
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
