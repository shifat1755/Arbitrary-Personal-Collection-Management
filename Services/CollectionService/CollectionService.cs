using APCM.Data;
using APCM.Models;
using APCM.Models.Collection;
using APCM.Models.Entities;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                collection = mapCommonFields(data, collection);
                collection.CreatedAt=DateTime.Now;
                foreach(var item in data.CustomFields)
                {
                    var customItem = new CustomField()
                    {
                        Name = item.Name,
                        Type = item.Type,
                        CollectionId=data.Id
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
        public Collection mapCommonFields(CreateCollectionViewModel model,Collection collection)
        {
            collection.Title = model.Title;
            collection.Category=model.Category;
            collection.Description = model.Description;
            collection.UserId = model.UserId;
            return collection;
        }

        public async Task<Collection> removeCustomFields(List<CustomField>customFields,Collection collection)
        {

            return collection;
        }
        public async Task<Collection> mapCustomFields(CreateCollectionViewModel model, Collection collection)
        {   
            List<CustomField>toRemove = new List<CustomField>();
            foreach(var item in collection.CustomFields)
            {
                foreach(var item2 in model.CustomFields)
                {
                    if (item.Id == item2.Id){ continue;}
                }
                toRemove.Add(item);
            }
            collection = await removeCustomFields(toRemove, collection);
            return collection;
        }
        public async Task<Response<object>> EditCollection(CreateCollectionViewModel model)
        {
            var response = new Response<object>();
            try
            {
                var collection = await _dbContext.Collections.Include(c => c.CustomFields).FirstAsync(c => c.Id == model.Id);
                collection=mapCommonFields(model,collection);
                collection=await mapCustomFields(model,collection);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message); 
                response.isSuccessful = false;
            }
            return response;
        }
        public async Task<Response<Collection>> GetCollection(Guid collectionId)
        {
            var response = new Response<Collection>();
            try
            {
                var data = await _dbContext.Collections
                    .Include(c => c.CustomFields)
                    .FirstOrDefaultAsync(x => x.Id == collectionId);
                response.isSuccessful = true;
                response.Data = data;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                response.isSuccessful = false;
            }
            return response;
        }
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
