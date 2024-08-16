using APCM.Models;
using APCM.Models.Entities;

namespace APCM.Services.HomeService
{
    public interface IHomeService
    {
        public Task<Response<List<Collection>>> RecentCollections(int a);
        public Task<Response<List<Collection>>> LargestCollections(int a);
    }
}
