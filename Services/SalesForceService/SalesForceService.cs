using APCM.Models;
using APCM.Models.Entities;
using APCM.Models.SalesForce;
using APCM.Services.SalesForceService;
using Newtonsoft.Json;
using RestSharp;

public class SalesforceService : ISalesForceService
{
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _username;
    private readonly string _password;
    private readonly string _securityToken;
    private readonly string _authUrl;
    private string _instanceUrl;
    private readonly RestClient _restClient;
    private string _accessToken;

    public SalesforceService(IConfiguration configuration)
    {
        _clientId = configuration["SalesforceSettings:ClientId"];
        _clientSecret = configuration["SalesforceSettings:ClientSecret"];
        _username = configuration["SalesforceSettings:Username"];
        _password = configuration["SalesforceSettings:Password"];
        _securityToken = configuration["SalesforceSettings:SecurityToken"];
        _authUrl = "https://login.salesforce.com/services/oauth2/token";
        _restClient = new RestClient();
    }

    private async Task<string> Authenticate()
    {
        var request = new RestRequest(_authUrl, Method.Post);
        request.AddParameter("grant_type", "password");
        request.AddParameter("client_id", _clientId);
        request.AddParameter("client_secret", _clientSecret);
        request.AddParameter("username", _username);
        request.AddParameter("password", _password + _securityToken);

        var response = await _restClient.ExecuteAsync(request);

        if (response.IsSuccessful)
        {
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
            _instanceUrl = jsonResponse.instance_url; // Extract the instance URL
            return jsonResponse.access_token;
        }
        else
        {
            var errorDetails = JsonConvert.DeserializeObject<dynamic>(response.Content);
            throw new Exception($"Salesforce authentication failed: {errorDetails.error_description}");
        }
    }


    public async Task<Response<List<string>>> CreateSalesforceAccountAndContact(CreateSalesForceViewModel model)
    {
        var response=new Response<List<string>>();
        try
        {
            _accessToken = Authenticate().GetAwaiter().GetResult();
            string accountId = await CreateAccountAsync(model.accountName);
            string contactId = await CreateContactAsync(model.firstName, model.lastName, model.email, accountId);
            response.isSuccessful = true;
        }
        catch (Exception ex) {
        Console.WriteLine(ex.Message);
            response.isSuccessful= false;
            response.Message = ex.Message;
        }
        return response;


    }

    public async Task<string> CreateAccountAsync(string accountName)
    {
        var request = new RestRequest($"{_instanceUrl}/services/data/v56.0/sobjects/Account", Method.Post);
        request.AddHeader("Authorization", $"Bearer {_accessToken}");
        request.AddHeader("Content-Type", "application/json");

        var accountData = new { Name = accountName };

        request.AddJsonBody(accountData);

        var response = await _restClient.ExecuteAsync(request);

        if (response.IsSuccessful)
        {
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return jsonResponse.id;
        }
        else
        {
            //var errorDetails = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return string.Empty;

        }
    }

    public async Task<string> CreateContactAsync(string firstName, string lastName, string email, string accountId)
    {
        var request = new RestRequest($"{_instanceUrl}/services/data/v56.0/sobjects/Contact", Method.Post);
        request.AddHeader("Authorization", $"Bearer {_accessToken}");
        request.AddHeader("Content-Type", "application/json");

        var contactData = new
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            AccountId = accountId
        };

        request.AddJsonBody(contactData);

        var response = await _restClient.ExecuteAsync(request);

        if (response.IsSuccessful)
        {
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return jsonResponse.id;
        }
        else
        {
            //var errorDetails = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return string.Empty;

        }
    }
}
