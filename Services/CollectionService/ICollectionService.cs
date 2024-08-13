using APCM.Models;
using APCM.Models.Collection;
using APCM.Models.Entities;

namespace APCM.Services.CollectionService
{
    public interface ICollectionService
    {
        public Task<Response> CreateCollection(CreateCollectionViewModel data);
        public Task<Response> UpdateCollection(CreateCollectionViewModel data);
        public Task<Response> DeleteCollection(int id);/*
        public Collection addCustomFields(CreateCollectionViewModel model, Collection collection, string typeToAdd, int num);*/
    }
}
