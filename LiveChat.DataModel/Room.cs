using System.Collections.Generic;

namespace LiveChat.DomainModel
{
    public class Room
    {
        public Room()
        {
            Users = new List<User>();
            Messages = new List<Message>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public List<User> Users { get; set; }

        public List<Message> Messages { get; set; }
    }
}
