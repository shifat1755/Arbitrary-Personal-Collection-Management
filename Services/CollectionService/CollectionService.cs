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
    public class CollectionService : ICollectionService
    {
        private readonly ApplicationDbContext _dbContext;

        public CollectionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response<object>> CreateCollection(CreateCollectionViewModel data)
        {
            var response = new Response<object>();
            try
            {
                var user = await _dbContext.Users.FindAsync(data.UserId);
                var collection = MapCommonFields(data, new Collection());
                collection.CreatedAt = DateTime.Now;
                foreach (var item in data.CustomFields)
                {
                    var customItem = new CustomField
                    {
                        Name = item.Name,
                        Type = item.Type
                    };
                    collection.CustomFields.Add(customItem);
                }
                user.Collections.Add(collection);
                await _dbContext.SaveChangesAsync();
                response.isSuccessful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.isSuccessful = false;
            }
            return response;
        }

        public Collection MapCommonFields(CreateCollectionViewModel model, Collection collection)
        {
            collection.Title = model.Title;
            collection.Category = model.Category;
            collection.Description = model.Description;
            collection.UserId = model.UserId;
            return collection;
        }

        public async Task RemoveDeletedCustomField(CreateCollectionViewModel model, Collection collection)
        {
            for (int i = collection.CustomFields.Count - 1; i >= 0; i--)
            {
                var item = collection.CustomFields.ElementAt(i);
                if (!model.CustomFields.Any(cf => cf.Id == item.Id))
                {
                    _dbContext.CustomFields.Remove(item);
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateExistingCustomField(CreateCollectionViewModel model, Collection collection)
        {
            foreach (var item in collection.CustomFields)
            {
                var matchedField = model.CustomFields.FirstOrDefault(cf => cf.Id == item.Id);
                if (matchedField != null)
                {
                    item.Name = matchedField.Name;
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddNewCustomField(CreateCollectionViewModel model, Collection collection)
        {
            foreach (var cf in model.CustomFields)
            {
                if (!collection.CustomFields.Any(item => item.Id == cf.Id))
                {
                    var newItem = new CustomField
                    {
                        Name = cf.Name,
                        Type = cf.Type,
                        CollectionId = collection.Id
                    };
                    await _dbContext.CustomFields.AddAsync(newItem);
                    collection.CustomFields.Add(newItem);
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Response<object>> EditCollection(CreateCollectionViewModel model)
        {
            var response = new Response<object>();
            try
            {
                var collection = await _dbContext.Collections
                    .Include(c => c.CustomFields)
                    .FirstAsync(c => c.Id == model.Id);

                collection = MapCommonFields(model, collection);
                await RemoveDeletedCustomField(model, collection);
                await UpdateExistingCustomField(model, collection);
                await AddNewCustomField(model, collection);
                response.isSuccessful = true;
            }
            catch (Exception ex)
            {
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
                    .Include(c=>c.Items)
                        .ThenInclude(i=>i.CustomFieldValues)
                    .Include(c => c.Items)
                        .ThenInclude(i => i.Likes)
                    .Include(c => c.Items)
                        .ThenInclude(i => i.Comments)
                    .FirstOrDefaultAsync(x => x.Id == collectionId);
     
                    response.isSuccessful = true;
                    response.Data = data;
                
            }
            catch (Exception ex) {
            
                Console.WriteLine(ex.Message);
                response.isSuccessful = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<object>> Delete(string id)
        {
            var response = new Response<object>();
            Guid Gid=Guid.Parse(id);
            var collection = await _dbContext.Collections.FirstOrDefaultAsync(i => i.Id == Gid);
            _dbContext.Collections.Remove(collection);
            await _dbContext.SaveChangesAsync();
            response.isSuccessful = true;
            return response;
        }
        public async Task<Response<List<Collection>>> GetAllCollection()
        {
            var response=new Response<List<Collection>>();
            try
            {
                var data = await _dbContext.Collections
                    .Include(c => c.Items)
                    .ToListAsync();
                response.isSuccessful = true;
                response.Data = data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                response.isSuccessful = false;
            }
            return response;
        }

    }
}
