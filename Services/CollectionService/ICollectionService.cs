using APCM.Models;
using APCM.Models.Collection;
using APCM.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APCM.Services.CollectionService
{
    public interface ICollectionService
    {
        public Task<Response<object>> CreateCollection(CreateCollectionViewModel data);
        public Task<Response<object>> Delete(string id);
        public Collection MapCommonFields(CreateCollectionViewModel model, Collection collection);
        public Task RemoveDeletedCustomField(CreateCollectionViewModel model, Collection collection);
        public Task UpdateExistingCustomField(CreateCollectionViewModel model, Collection collection);
        public Task AddNewCustomField(CreateCollectionViewModel model, Collection collection);
        public Task<Response<object>> EditCollection(CreateCollectionViewModel model);
        public Task<Response<Collection>> GetCollection(Guid collectionId);
        public Task<Response<List<Collection>>> GetAllCollection();

 }
}
