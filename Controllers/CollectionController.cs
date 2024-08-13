using APCM.Models.Collection;
using APCM.Services.CollectionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APCM.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionService _collectionService;
        public CollectionController(ICollectionService collectionService) { 
            _collectionService=collectionService;
        }
        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateCollectionViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) || string.IsNullOrWhiteSpace(model.Category))
            {
                return View(model);
            }
            else
            {
                model.UserId = int.Parse(User?.FindFirst("Id").Value);
                var response = await _collectionService.CreateCollection(model);
                return View(model);
            }

        }
    }
}
