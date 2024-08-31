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
        private readonly string _baseUrl = "https://shifat1755.atlassian.net/";
        private readonly string _email = "shifat1755@gmail.com";
        private readonly string _apiToken = "ATATT3xFfGF0pH4-ndGeoErjd7kDn0yxleacViIJ1VXuXcAzD2nBG4OOlCxdRdNj7gTymJuBeT1w-uBfdEw8i2gZTmRcDdKyXZfhbkF5_hMLITdNityTqdbV7RqTUOwRDS3V_2mSukGXMB8qzvOeVVevnDDuSGSHWp_n3Qks6t3uBsqhrIBNfvU=75C45022";
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
                        //id: 712020:38fef9eb - c394 - 4e56 - 8353 - ef4b9bb7f863
                        reporter = new { accountId = "712020:38fef9eb-c394-4e56-8353-ef4b9bb7f863" }
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
