using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Author> Authors { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne()
            .HasForeignKey(b => b.AuthorId)
            .IsRequired(false);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "J.R.R. Tolkien" },
            new Author { Id = 2, Name = "Jane Austen" },
            new Author { Id = 3, Name = "Douglas Adams" }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "The Lord of the Rings", AuthorId = 1 },
            new Book { Id = 2, Title = "The Hobbit", AuthorId = 1 },
            new Book { Id = 3, Title = "Pride and Prejudice", AuthorId = 2 },
            new Book { Id = 4, Title = "The Hitchhiker's Guide to the Galaxy", AuthorId = 3 }
        );
    }
}