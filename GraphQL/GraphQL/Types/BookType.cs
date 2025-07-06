using GraphQL.Models;

namespace GraphQL.GraphQL.Types
{
    public class BookType: ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Description("Represents a book.");

            descriptor.Field(b => b.Id).Description("The unique identifier of the book.");
            descriptor.Field(b => b.Title).Description("The title of the book.");
            descriptor.Field(b => b.Author).Description("The author of the book.");
        }
    }
}
