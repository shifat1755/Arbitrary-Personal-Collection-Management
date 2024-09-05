using APCM.Models;
using APCM.Models.SalesForce;

namespace APCM.Services.SalesForceService
{
    public interface ISalesForceService
    {
        public Task<Response<List<string>>> CreateSalesforceAccountAndContact(CreateSalesForceViewModel model);
        public Task<string> CreateAccountAsync(string accountName);
        public Task<string> CreateContactAsync(string firstName, string lastName, string email, string accountId);
    }
}
