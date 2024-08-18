using APCM.Models.Entities;
using APCM.Services.CollectionService;
using Microsoft.AspNetCore.Mvc;

namespace APCM.Controllers
{
    public class ItemController : Controller
    {
        private readonly ICollectionService _collectionService;

        public ItemController(ICollectionService collectionService) {
            _collectionService=collectionService;
        }
        [HttpGet]
        public async Task<IActionResult> Add(Guid collectionId)
        {
            var model = new Item()
            {
                CollectionId = collectionId,
                UserId=Guid.Parse(User?.FindFirst("Id").Value)
            };
            var collection = (await _collectionService.GetCollection(collectionId)).Data;
            foreach (var item in model.Collection.CustomFields) {
                var val = new CustomFieldValue()
                {
                    FieldName = item.Name,
                    Type = item.Type,
                };
                model.CustomFieldValues.Add(val);
            }
            return View(model);
        }
    }
}
