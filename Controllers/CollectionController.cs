using APCM.Models.Collection;
using Microsoft.AspNetCore.Mvc;

namespace APCM.Controllers
{
    public class CollectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateCollectionViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateCollectionViewModel model)
        {
            return View(model);
        }
    }
}
