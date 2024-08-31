using APCM.Models.JiraTicket;
using APCM.Services.JiraService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APCM.Controllers
{
    public class TicketController : Controller
    {
        private readonly IJiraService _jiraService;

        public TicketController(IJiraService jiraService) {
            _jiraService = jiraService;
        }
        [HttpGet]
        public IActionResult CreateTicket()
        {
            var model=new CreateTicketViewModel();
            var prevUrl = Request.Headers["Referer"].ToString();
            model.PrevUrl = prevUrl;
            return View(model);
        }

        [Authorize(Roles="Admin,User")]
        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketViewModel model)
        {
            model.UserEmail = User.FindFirst("Email").Value;
            model.UserID = Guid.Parse(User.FindFirst("Id").Value);
            model.CreateDate = DateTime.Now;
            var response=_jiraService.CreateJiraTicket(model);
            return View(model);

        }
    }
}
