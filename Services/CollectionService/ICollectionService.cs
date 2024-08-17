using APCM.Models;
using APCM.Models.Collection;
using APCM.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APCM.Services.CollectionService
{
    public interface ICollectionService
    {
        public Task<Response<object>> CreateCollection(CreateCollectionViewModel data);
        public Task<Response<object>> UpdateCollection(CreateCollectionViewModel data);
        public Task<Response<object>> DeleteCollection(int id);
        public Collection mapCommonFields(CreateCollectionViewModel model, Collection collection);
        public Task<Collection> mapCustomFields(CreateCollectionViewModel model, Collection collection);
        public Task<Collection> removeCustomFields(List<CustomField> customFields, Collection collection);
        public Task<Response<object>> EditCollection(CreateCollectionViewModel model);
        public Task<Response<Collection>> GetCollection(Guid collectionId);

        /*        public CustomField mapCustomFields(CustomField customField, CustomFieldViewModel model);*/
    }
}
