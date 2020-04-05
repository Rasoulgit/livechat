using LiveChat.Data.Repositories.Abstract;
using LiveChat.Data.Repositories.Concrete;
using System.Threading.Tasks;

namespace LiveChat.Data
{
    public class DataUnitOfWork : IDataUnitOfWork
    {
        private LiveChatContext _liveChatContext;
        private IRoomRepository _rooms;

        public DataUnitOfWork(LiveChatContext context)
        {
            _liveChatContext = context;
        }

        public IRoomRepository Rooms => _rooms ?? (_rooms = new RoomRepository(_liveChatContext));

        public async Task SaveChangeAsync()
        {
            await Task.Delay(5);
        }
    }
}
