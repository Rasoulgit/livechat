using LiveChat.Data;
using LiveChat.Domain.Chat.Abstract;
using LiveChat.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveChat.Domain.Chat.Concrete
{
    public class RoomService : IRoomService
    {
        private readonly IDataUnitOfWork dataUnitOfWork;

        public RoomService(IDataUnitOfWork dataUnitOfWork)
        {
            this.dataUnitOfWork = dataUnitOfWork;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await dataUnitOfWork.Rooms.GetAllAsync();
        }
    }
}
