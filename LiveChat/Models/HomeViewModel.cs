using System.Collections.Generic;

namespace LiveChat.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Rooms = new Dictionary<int, string>();
        }

        public Dictionary<int, string> Rooms { get; set; }
    }
}