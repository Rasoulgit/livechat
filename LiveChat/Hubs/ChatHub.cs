using LiveChat.Domain.Chat.Abstract;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace LiveChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService chatService;
        private readonly IUserValidator userValidator;

        public ChatHub(IChatService chatService, IUserValidator userValidator)
        {
            this.chatService = chatService;
            this.userValidator = userValidator;
        }

        public async Task SendMessage(string user, int roomId, string message)
        {
            await chatService.AddMessage(user, roomId, message);

            await Clients.All.SendAsync("ReceiveMessage", user, roomId, message);
        }

        public async Task ValidateUser(string user)
        {
            var valitionResult = userValidator.Validate(user);

            await Clients.Caller.SendAsync("DisplayValidation", valitionResult.Success, valitionResult.Error);
        }

        public async Task LoadRoomMessages(int roomId)
        {
            var messages = await chatService.GeMessagesByRoom(roomId);

            await Clients.Caller.SendAsync("DisplayRoom", messages);
        }
    }
}
