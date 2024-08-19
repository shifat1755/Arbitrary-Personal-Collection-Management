using APCM.Models;
using APCM.Models.Entities;
using APCM.Models.Item;

namespace APCM.Services.ItemService
{
    public interface IItemService
    {
        public Task<Response<object>> addItem(AddItemViewModel model);/*
        public Task addCustomFieldValue(CustomFieldValue model, Item item);*/

    }
}
