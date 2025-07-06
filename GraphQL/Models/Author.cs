﻿namespace GraphQL.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
