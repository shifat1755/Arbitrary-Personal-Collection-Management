using APCM.Models;

namespace APCM.Services.Like
{
    public interface ILikeService
    {
        public Task<Response<object>> AddLike(Guid itemId,Guid userId);
    }
}
