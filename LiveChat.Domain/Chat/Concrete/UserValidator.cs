using LiveChat.Domain.Chat.Abstract;
using LiveChat.Domain.Chat.Models;

namespace LiveChat.Domain.Chat.Concrete
{
    public class UserValidator : IUserValidator
    {
        public ValidationResult Validate(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                return ValidationResult.WithError("Username cannot be empty.");
            }

            return ValidationResult.WithSuccess();
        }
    }
}
