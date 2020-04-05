using System;


namespace LiveChat.DomainModel
{
    public class Message
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
