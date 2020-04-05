using LiveChat.Domain.Chat.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveChat.Domain.Chat.Abstract
{
    public interface IChatService
    {
        Task AddMessage(string user, int roomId, string message);
        Task<List<string>> GeMessagesByRoom(int roomId);
    }
}