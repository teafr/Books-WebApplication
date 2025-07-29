using booksAPI.Models;
using booksAPI.Models.GutendexModels;

namespace booksAPI.Services
{
    public interface IBookService
    {
        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>A collection of all books.</returns>
        Task<ICollection<BookModel>> GetAllBooksAsync();

        /// <summary>
        /// Gets a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        /// <returns>The book with the specified ID.</returns>
        Task<BookModel?> GetBookByIdAsync(int id);

        /// <summary>
        /// Gets a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        /// <returns>The book with the specified ID.</returns>
        Task<List<GutendexBook>?> GetBooksByIdsAsync(List<int> id);

        /// <summary>
        /// Searches books by a given query.
        /// </summary>
        /// <param name="query">Pattern.</param>
        Task<ICollection<BookModel>> SearchBooksByPatternAsync(string query);

        /// <summary>
        /// Searches books by topic.
        /// </summary>
        /// <param name="topic">Topic to find books by.</param>
        Task<ICollection<BookModel>> SearchBooksByTopicAsync(string topic);

        /// <summary>
        /// Sorts books by a given query.
        /// </summary>
        /// <param name="query">Pattern.</param>
        /// <returns></returns>
        Task<ICollection<BookModel>> SortBooksAsync(string query);
    }
}
