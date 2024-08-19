using APCM.Data;
using APCM.Models;
using APCM.Models.Entities;
using APCM.Models.Item;

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
        public async Task<Response<object>> addItem(AddItemViewModel model)
        {
            var response = new Response<object>();
            try
            {
                var item = new Item()
                {
                    UserId = model.UserId,
                    CollectionId= model.CollectionId,
                    Title = model.Title,
                    CreatedDate = DateTime.Now,
                };
                await _dbContext.Items.AddAsync(item);
                await _dbContext.SaveChangesAsync();
                foreach (var val in model.CustomFieldValues) {
                    var customFieldVal = new CustomFieldValue()
                    {
                        FieldName = val.FieldName,
                        Value = val.Value,
                        Type = val.Type,
                        ItemId = item.Id,
                    };
                    await _dbContext.CustomFieldValues.AddAsync(customFieldVal);
                    item.CustomFieldValues.Add(customFieldVal);
                    await _dbContext.SaveChangesAsync();
                
                }
                response.isSuccessful = true;
            }
            catch (Exception ex) { 
            Console.WriteLine(ex.ToString());
                response.isSuccessful= false;
            }
            return response;
        }
    }
}
