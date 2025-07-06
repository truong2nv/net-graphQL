using GraphQL.Models;
using GraphQL.Services;
using HotChocolate.Types.Pagination;


namespace GraphQL.GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class BookQuery
    {
        [GraphQLDescription("Gets all available books.")]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([Service] IBookService bookService) => bookService.GetBooks();

        [GraphQLDescription("Gets a book by its unique ID.")]
        public async Task<Book?> GetBookAsync(int id, [Service] IBookService bookService) => await bookService.GetBookByIdAsync(id);
    }
}
