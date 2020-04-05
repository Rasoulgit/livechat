
using LiveChat.Domain.Chat.Models;

namespace LiveChat.Domain.Chat.Abstract
{
    public interface IUserValidator
    {
        ValidationResult Validate(string user);
    }
}
