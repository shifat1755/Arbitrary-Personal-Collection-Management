using APCM.Models;
using APCM.Models.JiraTicket;
using Nest;
using Newtonsoft.Json;
using RestSharp;
using System.Text;

namespace APCM.Services.JiraService
{
    public class JiraService
    {
        private readonly string _baseUrl;
        private readonly string _email;
        private readonly string _apiToken;
        private readonly string _personalAccountId;
        public JiraService(IConfiguration configuration) {
            _apiToken = configuration["JiraSettings:ApiKey"];
            _email = configuration["JiraSettings:Email"];
            _baseUrl = configuration["JiraSettings:BaseUrl"];


        }
        public async Task<Response<object>> CreateJiraTicket(CreateTicketViewModel model)
        {
            var response=new Response<object>();
            try
            {
                var client = new RestClient(_baseUrl);
                var request = new RestRequest("rest/api/2/issue", Method.Post);

                var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_email}:{_apiToken}"));
                request.AddHeader("Authorization",$"Basic {authToken}");
                request.AddHeader("Content-Type","application/json");

                var issueData = new
                {
                    fields = new
                    {
                        project =new {key="KAN"},
                        summary=model.Summary,
                        description = model.Description,
                        issuetype = new {name="Task"},
                        //priority = new { name = model.Priority },
                        reporter = new { accountId = _personalAccountId }
                        //reporter=new { emailAddress = model.UserEmail }

                    }
                };
                request.AddJsonBody(JsonConvert.SerializeObject(issueData));
                var res= await client.ExecuteAsync(request);
                response.isSuccessful = true;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                response.isSuccessful = false;
            }
            return response;

        }
    }
}
