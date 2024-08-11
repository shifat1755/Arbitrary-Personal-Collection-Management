using APCM.Data;
using APCM.Models;
using APCM.Models.Collection;

namespace APCM.Services.CollectionService
{
    public class CollectionService:ICollectionService
    {
        private readonly ApplicationDbContext _dbContext;

        public CollectionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response> CreateCollection(CreateCollectionViewModel data)
        {
            var response=new Response();

            return response;
        }
        public async Task<Response> UpdateCollection(CreateCollectionViewModel data)
        {
            var response = new Response();
            return response;
        }
        public async Task<Response> DeleteCollection(int id)
        {
            var response = new Response();
            return response;
        }
    }
}
