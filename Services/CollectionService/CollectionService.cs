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
        public async Task<Response> CreateCollection(CreateCollectionViewModel data)
        {
            var response=new Response();
/*            try
            {
                var collection = new Collection()
                {
                    Title = data.Title,
                    Description = data?.Description,
                    UserId = data.UserId,
                    Category = data?.Category,
                };
                int maxFieldCount = 3;
                collection = addCustomFields(data, collection, "CustomInt", maxFieldCount);
                collection = addCustomFields(data, collection, "CustomString", maxFieldCount);
                collection = addCustomFields(data, collection, "CustomMultilineText", maxFieldCount);
                collection = addCustomFields(data, collection, "CustomDate", maxFieldCount);
                collection = addCustomFields(data, collection, "CustomBool", maxFieldCount);

                await _dbContext.Collections.AddAsync(collection);
                await _dbContext.SaveChangesAsync();
                response.isSuccessful = true;
            }
            catch (Exception ex) { 
                Console.WriteLine($"===============>{ex.ToString()}");
                response.isSuccessful = false;
            }*/
            return response;
        }
/*        public Collection addCustomFields(CreateCollectionViewModel model, Collection collection, string typeToAdd,int num)
        {
            int count = 0;

            for (int i=1; i<=num; i++)
            {
                string fieldKey=$"{typeToAdd}{i}";
                string valKey = $"{typeToAdd}{i}Val";
                var modelFieldKey =model.GetType().GetProperty(fieldKey);
                var modelFieldValKey = model.GetType().GetProperty(valKey);
                var modelFieldValue = modelFieldKey.GetValue(model);
                var modelFieldValValue = modelFieldValKey.GetValue(model);

                var colFieldKey = collection.GetType().GetProperty(fieldKey);
                var colFieldValKey = collection.GetType().GetProperty(valKey);

                colFieldKey.SetValue(collection,modelFieldValue);
                colFieldValKey.SetValue(collection, modelFieldValValue);

                if (modelFieldValue != null)
                {
                    count++;
                }
            }
            string colCount = $"{typeToAdd}Count";
            var colFieldCount=collection.GetType().GetProperty(colCount);
            colFieldCount.SetValue(collection,count);
            return collection;
        }*/
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
