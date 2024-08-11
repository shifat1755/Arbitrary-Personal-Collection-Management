using APCM.Models;
using APCM.Models.Collection;

namespace APCM.Services.CollectionService
{
    public interface ICollectionService
    {
        public Task<Response> CreateCollection(CreateCollectionViewModel data);
        public Task<Response> UpdateCollection(CreateCollectionViewModel data);
        public Task<Response> DeleteCollection(int id);
    }
}
