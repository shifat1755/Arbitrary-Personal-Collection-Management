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

            var response =await _jiraService.GetJiraAccountId(model.UserEmail);
            if (response.isSuccessful == false) {
                var response2 = await _jiraService.CreateJiraUser(model.UserEmail);
                if (response2.isSuccessful == false) {
                    return View(model);
                }
                model.jiraAccountId = (await _jiraService.GetJiraAccountId(model.UserEmail)).Message;
            }
            model.CreateDate = DateTime.Now;
            var response3 = _jiraService.CreateJiraTicket(model);
            return View(model);

        }
    }
}
