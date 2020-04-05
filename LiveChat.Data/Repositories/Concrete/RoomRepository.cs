using LiveChat.Data.Repositories.Abstract;
using LiveChat.DomainModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveChat.Data.Repositories.Concrete
{
    public class RoomRepository : IRoomRepository
    {
        private LiveChatContext context;

        public RoomRepository(LiveChatContext context)
        {
            this.context = context;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            // Stimulate async
            await Task.Delay(5);

            return context.Rooms;
        }

        public async Task<Room> GetAsync(int Id)
        {
            await Task.Delay(5);

            return context.Rooms.Single(x => x.Id == Id);
        }
    }
}
