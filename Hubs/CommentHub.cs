using APCM.Services.CommentService;
using Microsoft.AspNetCore.SignalR;

namespace APCM.Hubs
{
    public class CommentHub:Hub
    {
        private readonly ICommentService _commentService;

        public CommentHub(ICommentService commentService) {
            _commentService= commentService;
        }

        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;
            string itemId = Context.GetHttpContext().Request.Query["id"];
            if (!string.IsNullOrEmpty(itemId))
            {
                await Groups.AddToGroupAsync(connectionId, itemId);
                await Clients.Group(itemId).SendAsync("UserJoined", connectionId);
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string connectionId = Context.ConnectionId;
            string itemId = Context.GetHttpContext().Request.Query["id"];
            if (!string.IsNullOrEmpty(connectionId))
            {
                await Groups.RemoveFromGroupAsync(connectionId, itemId);
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task sendComment(string user, string comment)
        {
            await Clients.All.SendAsync("ReceiveMassage",user, comment);
        }

    }
}
