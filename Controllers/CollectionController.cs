using APCM.Data;
using APCM.Models.Collection;
using APCM.Services.CollectionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCM.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionService _collectionService;
        private readonly ApplicationDbContext _dbContext;

        public CollectionController(ICollectionService collectionService, ApplicationDbContext dbContext) { 
            _collectionService=collectionService;
            _dbContext=dbContext;
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
                model.UserId =Guid.Parse(User?.FindFirst("Id").Value);
                var response = await _collectionService.CreateCollection(model);
                return View(model);
            }

        }
        [HttpGet]
        public async Task<IActionResult>Edit(Guid id)
        {
            var ss= await _dbContext.Collections.FirstOrDefaultAsync(c=>c.Title== "kljdkled");
            var collection = await _dbContext.Collections.Include(c => c.CustomFields).FirstOrDefaultAsync(c => c.Id ==ss.Id);
            var data = new CreateCollectionViewModel()
            {
                Id = collection.Id,
                UserId=collection.UserId,
                Title=collection.Title,
                Category=collection.Category,
                Description=collection.Description,
                CustomFields=collection.CustomFields.Select(cf=>new CustomFieldViewModel{
                Id=cf.Id,
                Type=cf.Type,
                Name=cf.Name,
                }).ToList(),
                isEdit=true,
            };

            return View("Create",data);
        }
        [HttpPost]
        public IActionResult Edit(CreateCollectionViewModel model)
        {
            return View("Create", model);
        }
    }
}
