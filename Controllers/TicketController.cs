using APCM.Data;
using APCM.Models.JiraTicket;
using APCM.Services.JiraService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APCM.Controllers
{
    public class TicketController : Controller
    {
        private readonly IJiraService _jiraService;
        private readonly ApplicationDbContext _dbContex;

        public TicketController(IJiraService jiraService, ApplicationDbContext dbContext) {
            _jiraService = jiraService;
            _dbContex = dbContext;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult>Index(string jiraId)
        {
            var ressponse=await _jiraService.GetIssuesReportedByUser(jiraId);
            return View(ressponse.Data);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> CreateTicket()
        {
            var model=new CreateTicketViewModel();
            
            model.UserID = Guid.Parse(User.FindFirst("Id").Value);
            string UserEmail = User.FindFirst("Email").Value;
            model.UserEmail=UserEmail;
            var user = await _dbContex.Users.FindAsync(model.UserID);
            if (user.JiraAccountId == null)
            {
                var response = await _jiraService.CreateJiraUser(model.UserEmail);
                user.JiraAccountId=response.Message;
                await _dbContex.SaveChangesAsync();
            }
            model.jiraAccountId = user.JiraAccountId;
            
            var prevUrl = Request.Headers["Referer"].ToString();
            model.PrevUrl = prevUrl;
            if (prevUrl.Contains("Details"))
            {
                int detailsIndex = prevUrl.IndexOf("Details");
                string key = prevUrl.Substring(detailsIndex + "Details/".Length);
                Guid Gkey= Guid.Parse(key);
                var collection=await _dbContex.Collections.FindAsync(Gkey);
                model.CollectionName = collection.Title;
            }

            return View(model);
        }

        [Authorize(Roles="Admin,User")]
        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketViewModel model)
        {
            model.CreateDate = DateTime.Now;
            var response3 = await _jiraService.CreateJiraTicket(model);
            if ((model.jiraAccountId != null)&&(response3.isSuccessful==true)) {
                return RedirectToAction("Index", new { jiraId = model.jiraAccountId });
            }
            return View(model);

        }
    }
}
