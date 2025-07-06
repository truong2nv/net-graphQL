using GraphQL.Models;
using GraphQL.Services;

namespace GraphQL.GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class AuthorMutation
    {
        [GraphQLDescription("Adds a new author.")]
        public async Task<Author> AddAuthorAsync(string name, [Service] IAuthorService authorService)
        {
            var author = new Author { Name = name };
            return await authorService.AddAuthorAsync(author);
        }
    }
}
