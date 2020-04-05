using LiveChat.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveChat.Data.Repositories.Abstract
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();
        Task<Room> GetAsync(int Id);
    }
}
