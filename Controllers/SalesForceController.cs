using APCM.Data;
using APCM.Models.SalesForce;
using APCM.Services.SalesForceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCM.Controllers
{
    public class SalesForceController : Controller
    {

        private readonly ISalesForceService _salesForceService;
        private readonly ApplicationDbContext _dbContext;

        public SalesForceController(ISalesForceService salesForceService, ApplicationDbContext dbContext)
        {
            _salesForceService = salesForceService;
            _dbContext= dbContext;
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new CreateSalesForceViewModel();
            string email = User?.FindFirst("Email").Value;
            model.email = email;
            return View(model);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public async Task<IActionResult> Index(CreateSalesForceViewModel model)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(i => i.Email == model.email);
            if (user.SFContactName != null) {
                return RedirectToAction("Index", "User");
            }
            var response =await _salesForceService.CreateSalesforceAccountAndContact(model);
            if (response.isSuccessful == true)
            {
                user.SFContactName = $"{model.firstName} {model.lastName}";
                user.SFCompanyName=model.accountName;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "User", new { id = user.Id.ToString() });

            }
            return View(model);
        }
    }
}
