using APCM.Models;
using APCM.Models.Collection;
using APCM.Models.Entities;

namespace APCM.Services.CollectionService
{
    public interface ICollectionService
    {
        public Task<Response<object>> CreateCollection(CreateCollectionViewModel data);
        public Task<Response<object>> UpdateCollection(CreateCollectionViewModel data);
        public Task<Response<object>> DeleteCollection(int id);
        public Collection mapCollectionFields(CreateCollectionViewModel model, Collection collection);
/*        public CustomField mapCustomFields(CustomField customField, CustomFieldViewModel model);*/
    }
}
