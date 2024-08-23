using APCM.Data;
using APCM.Models;
using APCM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace APCM.Services.Like
{
    public class LikeService : ILikeService
    {
        private readonly ApplicationDbContext _dbContext;

        public LikeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response<object>> AddLike(Guid itemId, Guid userId)
        {
            var response = new Response<object>();
            try
            {
                var exist = await _dbContext.Likes.FirstOrDefaultAsync(i => i.UserId == userId && i.ItemId == itemId);
                if (exist != null)
                {
                    _dbContext.Remove(exist);
                    response.Message = "unLiked";
                }
                else
                {
                    var like = new APCM.Models.Entities.Like()
                    {
                        UserId = userId,
                        ItemId = itemId
                    };
                    _dbContext.Likes.Add(like);
                    response.Message = "liked";
                    
                }
                _dbContext.SaveChanges();
                response.isSuccessful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.isSuccessful = false;
            }
            return response;

        }
    }
}
