﻿using GraphQL.Models;

namespace GraphQL.GraphQL.Types
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Description("Represents an author.");

            descriptor.Field(a => a.Id).Description("The unique identifier of the author.");
            descriptor.Field(a => a.Name).Description("The name of the author.");
            descriptor.Field(a => a.Books).Description("The books written by the author.");
        }
    }
}
