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
        public async Task<IActionResult> Index()
        {
            var data = (await _collectionService.GetAllCollection()).Data;
            ViewBag.Collections = data;
            return View();
        }


        public async Task<IActionResult> Details(string id)
        {
            var Gid=Guid.Parse(id);
            var data = new CollectionDetailsViewModel()
            {
                Collection = (await _collectionService.GetCollection(Gid)).Data,
            };
            data.Items=await _dbContext.Items
                .Where(x => x.CollectionId ==Gid )
                .Include(c=>c.CustomFieldValues)

                .ToListAsync();
            return View(data);
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
                return RedirectToAction("Index","Home");
                /*return View(model);*/
            }

        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public async Task<IActionResult>Edit(Guid id)
        {
            var collection = await _dbContext.Collections.Include(c => c.CustomFields).FirstOrDefaultAsync(c => c.Id ==id);
            var data = new CreateCollectionViewModel()
            {
                Id = collection.Id,
                UserId=collection.UserId,
                Title=collection.Title,
                Category=collection.Category,
                Description=collection.Description,
                CustomFields=collection.CustomFields?.Select(cf=>new CustomFieldViewModel{
                    Id=cf.Id,
                    Type = cf.Type,
                    Name=cf.Name,
                }).ToList(),
                isEdit=true,
            };

            return View("Create",data);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(CreateCollectionViewModel model)
        {
            var response=await _collectionService.EditCollection(model);
            if (response.isSuccessful == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Create", model);

        }
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _collectionService.Delete(id);
            string previousUrl = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(previousUrl))
            {
                return Redirect(previousUrl);
            }
            return RedirectToAction("Index");
        }


    }
}
