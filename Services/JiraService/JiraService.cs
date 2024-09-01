using APCM.Models;
using APCM.Models.JiraTicket;
using Nest;
using Newtonsoft.Json;
using RestSharp;
using System.Text;

namespace APCM.Services.JiraService
{
    public class JiraService:IJiraService
    {
        private readonly string _baseUrl;
        private readonly string _email;
        private readonly string _apiToken;
        private readonly string _personalAccountId;
        public JiraService(IConfiguration configuration) {
            _apiToken = configuration["JiraSettings:ApiKey"];
            _email = configuration["JiraSettings:Email"];
            _baseUrl = configuration["JiraSettings:BaseUrl"];
            _personalAccountId= configuration["JiraSettings:PersonalAccountId"];

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
                        project = new { key = "APCM" },
                        summary = model.Summary,
                        issuetype = new { name = "Ticket" },
                        customfield_10041 = model.Priority,
                        reporter = new { accountId = model.jiraAccountId},
                        customfield_10037 = model.PrevUrl,
                        //customfield_10039=model.CollectionName
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
        public async Task<Response<object>> GetJiraAccountId(string email)
        {
            var res = new Response<object>();
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"rest/api/3/user/search?query={email}", Method.Get);

            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_email}:{_apiToken}"));
            request.AddHeader("Authorization", $"Basic {authToken}");
            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            dynamic users = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);


            if (response.IsSuccessful && users && users[0].Length!=0)
            {
                var accountId = users[0].accountId.ToString();
                res.isSuccessful = true;
                res.Message = accountId;
            }
            else
            {
                res.isSuccessful = false;
                res.Message = $"Error retrieving Jira Account ID: {response.ErrorMessage}";
            }
            return res;
        }

        public async Task<Response<object>> CreateJiraUser(string email)
        {
            var response = new Response<object>();
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("rest/api/3/user", Method.Post);

            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_email}:{_apiToken}"));
            request.AddHeader("Authorization", $"Basic {authToken}");
            request.AddHeader("Content-Type", "application/json");

            var userData = new
            {
                emailAddress = email,
                products = new List<string> { "jira-software" }
            };

            request.AddJsonBody(JsonConvert.SerializeObject(userData));
            var res = await client.ExecuteAsync(request);

            if (res.IsSuccessful)
            {
                response.isSuccessful = true;
                response.Data = res.Content;
            }
            else
            {
                response.isSuccessful = false;
                response.Message = res.ErrorMessage;
            }
            return response;
        }

    }
}
