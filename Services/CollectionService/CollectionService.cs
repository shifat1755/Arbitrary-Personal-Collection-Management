using APCM.Data;
using APCM.Models;
using APCM.Models.Collection;
using APCM.Models.Entities;
using System.Security.Claims;

namespace APCM.Services.CollectionService
{
    public class CollectionService:ICollectionService
    {
        private readonly ApplicationDbContext _dbContext;

        public CollectionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response<object>> CreateCollection(CreateCollectionViewModel data)
        {
            var response=new Response<object>();
            try
            {
                var collection = new Collection();
                collection = mapCollectionFields(data, collection);
                collection.CreatedAt=DateTime.Now;
                foreach(var item in data.CustomFields)
                {
                    var customItem = new CustomField()
                    {
                        Name = item.Name,
                        Type = item.Type,
                    };
                    /*customItem=mapCustomFields(customItem, item);*/
                    await _dbContext.AddAsync(customItem);
                    collection.CustomFields.Add(customItem);
                }

                await _dbContext.Collections.AddAsync(collection);
                await _dbContext.SaveChangesAsync();
                response.isSuccessful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"===============>{ex.ToString()}");
                response.isSuccessful = false;
            }
            return response;
        }
        public Collection mapCollectionFields(CreateCollectionViewModel model,Collection collection)
        {
            collection.Title = model.Title;
            collection.Category=model.Category;
            collection.Description = model.Description;
            collection.UserId = model.UserId;
            return collection;
        }
/*        public CustomField mapCustomFields(CustomField customField,CustomFieldViewModel model) {
            customField.Type = model.Type;
            customField.Name= model.Name;
            customField.Value = model.Value;
            return customField;

        }*/
        public async Task<Response<object>> UpdateCollection(CreateCollectionViewModel data)
        {
            var response=new Response<object>();
            return response;
        }
        public async Task<Response<object>> DeleteCollection(int id)
        {
            var response = new Response<object>();
            return response;
        }
    }
}
