namespace web_api_for_books_app.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetBookTextAsync(string fullTextUrl)
        {
            var bookText = await _httpClient.GetStringAsync(fullTextUrl);
            return bookText;
        }
    }
}
