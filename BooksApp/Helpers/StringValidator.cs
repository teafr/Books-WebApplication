namespace booksAPI.Helpers
{
    public static class StringValidator
    {
        public static void Validate(string? value, string nameOfValue)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameOfValue, "Argument is null.");
            }
            else if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value is empty.", nameOfValue);
            }
            else if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value contains only white spaces.", nameOfValue);
            }
        }
    }
}
