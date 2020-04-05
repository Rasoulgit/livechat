using LiveChat.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveChat.Domain.Chat.Abstract
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllAsync();
    }
}