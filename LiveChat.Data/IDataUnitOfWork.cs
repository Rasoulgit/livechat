using LiveChat.Data.Repositories.Abstract;
using System.Threading.Tasks;

namespace LiveChat.Data
{
    public interface IDataUnitOfWork
    {
        IRoomRepository Rooms { get; }

        Task SaveChangeAsync();
    }
}
