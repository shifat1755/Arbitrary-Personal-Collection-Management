using APCM.Models;
using APCM.Models.JiraTicket;

namespace APCM.Services.JiraService
{
    public interface IJiraService
    {
        public Task<Response<object>> CreateJiraTicket(CreateTicketViewModel model);
        public Task<Response<object>> GetJiraAccountId(string email);

        public Task<Response<object>> CreateJiraUser(string email);



    }
}
