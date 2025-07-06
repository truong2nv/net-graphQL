using GraphQL.Models;

namespace GraphQL.GraphQL.Subscriptions
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class BookSubscription
    {
        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscribes to new book additions.")]
        public Book OnBookAdded([EventMessage] Book book) => book;
    }
}
