using APCM.Data;
using APCM.Models.Entities;

namespace APCM.Services.CommentService
{
    public class CommentService:ICommentService
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentService(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task AddComment(Guid userId,string firstName, Guid itemId, string comment)
        {
            var data = new Comment()
            {
                Data = comment,
                ItemId = itemId,
                UserId = userId,
                firstName = firstName,
            };
            await _dbContext.Comments.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

    }
}
