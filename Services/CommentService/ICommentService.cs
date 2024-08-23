namespace APCM.Services.CommentService
{
    public interface ICommentService
    {
        public Task AddComment(Guid userId, string firstName, Guid itemId, string comment);
    }
}
