using LiveChat.DomainModel;
using System.Collections.Generic;

namespace LiveChat.Data
{
    public class LiveChatContext
    {
        public LiveChatContext()
        {
            Rooms = new List<Room>
            {
                new Room
                {
                    Id= 1,
                    Name = "Family"
                },
                new Room
                {
                    Id= 2,
                    Name = "Friends"
                },
                new Room
                {
                    Id= 3,
                    Name = "Work"
                }
            };
        }
        public List<Room> Rooms { get; set; }
    }
}
