using APCM.Models.Entities;
using APCM.Services.CommentService;
using APCM.Services.Like;
using Microsoft.AspNetCore.SignalR;

namespace APCM.Hubs
{
    public class LikeCommentHub : Hub
    {
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;

        public LikeCommentHub(ICommentService commentService, ILikeService likeService)
        {
            _commentService = commentService;
            _likeService=likeService;
        }
        public async Task SendComment(string itemId, string comment)
        {
            string userId = Context.User.FindFirst("Id")?.Value;
            string firstName = Context.User?.FindFirst("firstName")?.Value;
            await Clients.Groups(itemId).SendAsync("receiveComment", firstName, comment,userId);
            Guid GuserId=Guid.Parse(userId);
            Guid GItemId = Guid.Parse(itemId);
            await _commentService.AddComment(GuserId,firstName,GItemId,comment);

        }
        public async Task addLike(string itemId)
        {
            Guid userId = Guid.Parse(Context.User.FindFirst("Id")?.Value);
            Guid GitemId = Guid.Parse(itemId);
            var response = await _likeService.AddLike(GitemId,userId);
            if (response.isSuccessful == false) { return; }
            if (response.Message == "liked")
            {
                await Clients.Group(itemId).SendAsync("liked");
            }
            else { 
                await Clients.Group(itemId).SendAsync("unLiked");

            }
        }

        public override async Task OnConnectedAsync()
        {
            string connectionid = Context.ConnectionId;
            string itemid = Context.GetHttpContext().Request.Query["ItemId"];
            if (!string.IsNullOrEmpty(itemid))
            {
                await Groups.AddToGroupAsync(connectionid, itemid);
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string connectionId = Context.ConnectionId;
            string itemId = Context.GetHttpContext().Request.Query["ItemId"];
            if (!string.IsNullOrEmpty(connectionId))
            {
                await Groups.RemoveFromGroupAsync(connectionId, itemId);
            }
            await base.OnDisconnectedAsync(exception);
        }

    }
}