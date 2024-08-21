using APCM.Data;
using APCM.Models.Entities;
using APCM.Models.Item;
using APCM.Services.CollectionService;
using APCM.Services.ItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCM.Controllers
{
    public class ItemController : Controller
    {
        private readonly ICollectionService _collectionService;
        private readonly IItemService _itemService;
        private readonly ApplicationDbContext _dbContext;

        public ItemController(ICollectionService collectionService, IItemService itemService, ApplicationDbContext dbContext) {
            _collectionService=collectionService;
            _itemService=itemService;
            _dbContext=dbContext;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var data = new ItemViewModel()
            {
                Item = (await _itemService.GetItem(id)).Data
            };
            return View(data);
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
            var tags = await _dbContext.hashTags.ToListAsync();
            foreach (var tag in tags) {
                model.AllTags.Add(tag.Name);
            }
            return View(model);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel model)
        {
            var response = await _itemService.addItem(model);
            /*return View(model);*/
            return RedirectToAction("Details","Collection", new {id=model.CollectionId});
        }
    }
}
