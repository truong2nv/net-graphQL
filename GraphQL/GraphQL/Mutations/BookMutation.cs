using GraphQL.Models;
using GraphQL.Services;

namespace GraphQL.GraphQL.Mutation
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class BookMutation
    {
        [GraphQLDescription("Adds a new book.")]
        public async Task<Book> AddBookAsync(string title, string author, [Service] IBookService bookService)
        {
            var book = new Book { Title = title, Author = author };
            return await bookService.AddBookAsync(book);
        }

        [GraphQLDescription("Updates an existing book.")]
        public async Task<Book> UpdateBookAsync(int id, string? title, string? author, [Service] IBookService bookService)
        {
            var book = await bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                throw new GraphQLException(new Error("Book not found.", "BOOK_NOT_FOUND"));
            }
            if (!string.IsNullOrEmpty(title))
            {
                book.Title = title;
            }
            if (!string.IsNullOrEmpty(author))
            {
                book.Author = author;
            }
            return await bookService.UpdateBookAsync(book);
        }

        [GraphQLDescription("Deletes a book by its ID.")]
        public async Task<bool> DeleteBookAsync(int id, [Service] IBookService bookService)
        {
            return await bookService.DeleteBookAsync(id);
        }
    }
}
