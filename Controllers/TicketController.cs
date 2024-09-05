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
        
        [HttpGet]
        public async Task<IActionResult> CreateTicket()
        {
            var model=new CreateTicketViewModel();
            
            model.UserID = Guid.Parse(User.FindFirst("Id").Value);
            string UserEmail = User.FindFirst("Email").Value;
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
            
            return View(model);
        }

        [Authorize(Roles="Admin,User")]
        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketViewModel model)
        {
            model.CreateDate = DateTime.Now;
            var response3 = _jiraService.CreateJiraTicket(model);
            return View(model);

        }
    }
}
