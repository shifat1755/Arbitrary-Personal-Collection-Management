using APCM.Data;
using APCM.Models;
using APCM.Models.Entities;
using APCM.Models.Item;
using Microsoft.EntityFrameworkCore;

namespace APCM.Services.ItemService
{
    public class ItemService: IItemService
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemService(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        /*        public async Task addCustomFieldValue(CustomFieldValue val, Item item)
                {
                    item.
                }*/

        public async Task<Response<Item>> GetItem(Guid id)
        {
            var response= new Response<Item>();
            try
            {
                var item= await _dbContext.Items
                    .Include(i=>i.CustomFieldValues)
                    .Include(i=>i.Tags)
                    .Include(i=>i.Likes)
                    .Include(i=>i.Comments)
                    .FirstAsync(i=>i.Id==id);
                response.isSuccessful = true;
                response.Data = item;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                response.isSuccessful = false;
            }
            return response;
        }
        public async Task<Response<object>> addItem(AddItemViewModel model)
        {
            var response = new Response<object>();
            try
            {
                var item = new Item()
                {
                    UserId = model.UserId,
                    CollectionId = model.CollectionId,
                    Title = model.Title,
                    CreatedDate = DateTime.Now,
                };
                await _dbContext.Items.AddAsync(item);
                await _dbContext.SaveChangesAsync();

                foreach (var val in model.CustomFieldValues)
                {
                    var customFieldVal = new CustomFieldValue()
                    {
                        FieldName = val.FieldName,
                        Value = val.Value,
                        Type = val.Type,
                        ItemId = item.Id,
                    };
                    await _dbContext.CustomFieldValues.AddAsync(customFieldVal);
                    item.CustomFieldValues.Add(customFieldVal);
                }

                await mapTag(model.Tags, item);
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

        public async Task mapTag(List<string> tags, Item item)
        {
            var tagsToRemove = item.Tags.Where(t => !tags.Contains(t.Name)).ToList();
            foreach (var tag in tagsToRemove)
            {
                item.Tags.Remove(tag);
                tag.items.Remove(item);
            }
            await _dbContext.SaveChangesAsync();
            foreach (var tag in tags)
            {
                var existingTag = await _dbContext.hashTags.FindAsync(tag);
                if (existingTag != null)
                {
                    if (!item.Tags.Contains(existingTag))
                    {
                        item.Tags.Add(existingTag);
                        existingTag.items.Add(item);

                    }
                }
                else
                {
                    var newTag = new Tag()
                    {
                        Name = tag,
                    };
                    await _dbContext.hashTags.AddAsync(newTag);
                    newTag.items.Add(item);
                    item.Tags.Add(newTag);
                }
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
