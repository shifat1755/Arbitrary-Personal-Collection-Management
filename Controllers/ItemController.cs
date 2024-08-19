using APCM.Models.Entities;
using APCM.Models.Item;
using APCM.Services.CollectionService;
using APCM.Services.ItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APCM.Controllers
{
    public class ItemController : Controller
    {
        private readonly ICollectionService _collectionService;
        private readonly IItemService _itemService;

        public ItemController(ICollectionService collectionService, IItemService itemService) {
            _collectionService=collectionService;
            _itemService=itemService;
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public async Task<IActionResult> Add(Guid collectionId)
        {
            if (collectionId == Guid.Empty)
            {
                return BadRequest("Invalid Collection ID");
            }
            var model = new AddItemViewModel()
            {
                CollectionId = collectionId,
                UserId=Guid.Parse(User?.FindFirst("Id").Value)
            };
            var collection = (await _collectionService.GetCollection(collectionId)).Data;

            foreach (var item in collection.CustomFields) {
                var val = new CustomFieldValueViewModel()
                {
                    Id=Guid.NewGuid(),
                    FieldName = item.Name,
                    Type = item.Type,
                };
                model.CustomFieldValues.Add(val);
            }
            return View(model);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel model)
        {
            var response=await _itemService.addItem(model);
            return RedirectToAction("Details","Collection", new {id=model.CollectionId});
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
