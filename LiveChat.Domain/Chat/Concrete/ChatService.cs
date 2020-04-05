using LiveChat.Data;
using LiveChat.Domain.Chat.Abstract;
using LiveChat.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveChat.Domain.Chat.Concrete
{
    public class ChatService : IChatService
    {
        private readonly IDataUnitOfWork dataUnitOfWork;

        public ChatService(IDataUnitOfWork dataUnitOfWork)
        {
            this.dataUnitOfWork = dataUnitOfWork;
        }

        public async Task AddMessage(string user, int roomId, string message)
        {
            var room = await dataUnitOfWork.Rooms.GetAsync(roomId);

            var existingUser = room.Users.FirstOrDefault(x => x.UserName == user);

            if(existingUser == null)
            {
                existingUser = new User
                {
                    Id = room.Users.Count,
                    UserName = user
                };
            }

            var newMessage = new Message
            {
                User = existingUser,
                Content = message,
                CreatedDateTime = DateTime.Now,
                RoomId = roomId
            };

            room.Messages.Add(newMessage);

            await dataUnitOfWork.SaveChangeAsync();
        }

        public async Task<List<string>> GeMessagesByRoom(int roomId)
        {
            var room = await dataUnitOfWork.Rooms.GetAsync(roomId);

            var messages = room.Messages.Select(x => $"{x.User.UserName} : {x.Content}").ToList();

            return messages;
        }

        
    }
}
