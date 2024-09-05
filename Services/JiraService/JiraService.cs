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
        private readonly string _authToken;

        public JiraService(IConfiguration configuration) {
            _apiToken = configuration["JiraSettings:ApiKey"];
            _email = configuration["JiraSettings:Email"];
            _baseUrl = configuration["JiraSettings:BaseUrl"];
            _personalAccountId = configuration["JiraSettings:PersonalAccountId"];
            _authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{configuration["JiraSettings:Email"]}:{configuration["JiraSettings:ApiKey"]}"));

        }
        public async Task<Response<object>> CreateJiraTicket(CreateTicketViewModel model)
        {
            var _restClient = new RestClient(_baseUrl);
            var response =new Response<object>();
            try
            {
                var request = new RestRequest("rest/api/2/issue", Method.Post);
                request.AddHeader("Authorization",$"Basic {_authToken}");
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
                        customfield_10039=model.CollectionName
                    }
                };

                request.AddJsonBody(JsonConvert.SerializeObject(issueData));
                var res= await _restClient.ExecuteAsync(request);
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
            var _restClient = new RestClient(_baseUrl);
            var res = new Response<object>();
            var request = new RestRequest($"rest/api/3/user/search?query={email}", Method.Get);
            request.AddHeader("Authorization", $"Basic {_authToken}");
            request.AddHeader("Content-Type", "application/json");

            var response = await _restClient.ExecuteAsync(request);
            dynamic users = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);

            if (response.IsSuccessful && users.Count>0)
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
            var _restClient = new RestClient(_baseUrl);
            var response = new Response<object>();
            var request = new RestRequest("rest/api/3/user", Method.Post);
            request.AddHeader("Authorization", $"Basic {_authToken}");
            request.AddHeader("Content-Type", "application/json");

            var userData = new
            {
                emailAddress = email,
                products = new List<string> { "jira-software" }
            };

            request.AddJsonBody(JsonConvert.SerializeObject(userData));
            var res = await _restClient.ExecuteAsync(request);

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
        public async Task<Response<List<TicketListViewModel>>> GetIssuesReportedByUser(string jiraAccountId)
        {
            var response = new Response<List<TicketListViewModel>>();

            try
            {
                var _restClient = new RestClient(_baseUrl);
                var jql = $"reporter={jiraAccountId}";
                var request = new RestRequest("rest/api/3/search", Method.Get);
                request.AddHeader("Authorization", $"Basic {_authToken}");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("jql", jql);
                request.AddParameter("fields", "self,key,summary,status");

                var res = await _restClient.ExecuteAsync(request);

                if (res.IsSuccessful)
                {
                    dynamic issuesResponse = JsonConvert.DeserializeObject(res.Content);

                    var issues = new List<TicketListViewModel>();

                    foreach (var issue in issuesResponse.issues)
                    {
                        var issueKey = issue.key.ToString();
                        var issueLink = $"https://shifat1755.atlassian.net/jira/software/projects/APCM/boards/1?selectedIssue={issueKey}";
                        var issueSummary = issue.fields.summary.ToString();
                        var Status = issue.fields.status.name;
                        issues.Add(
                            new TicketListViewModel
                            {
                                summary= issueSummary,
                                link= issueLink,
                                status=Status,
                            }
                            
                            );
                    }

                    response.isSuccessful = true;
                    response.Data = issues;
                }
                else
                {
                    response.isSuccessful = false;
                    response.Message = $"Error retrieving issues: {res.ErrorMessage}";
                }
            }
            catch (Exception ex)
            {
                response.isSuccessful = false;
                response.Message = $"Exception occurred: {ex.Message}";
            }

            return response;
        }


    }
}
