namespace LiveChat.Domain.Chat.Models
{
    public class ValidationResult
    {
        private ValidationResult() { }

        public string Error { get; private set; }
        public bool Success { get; private set; }

        public static ValidationResult WithError(string error)
        {
            return new ValidationResult()
            {
                Success = false,
                Error = error
            };
        }

        public static ValidationResult WithSuccess()
        {
            return new ValidationResult()
            {
                Success = true
            };
        }
    }
}
