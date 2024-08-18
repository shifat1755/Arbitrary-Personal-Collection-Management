using APCM.Data;

namespace APCM.Services.ItemService
{
    public class ItemService: IItemService
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemService(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
    }
}
