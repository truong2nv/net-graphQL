using GraphQL.GraphQL.Mutation;
using GraphQL.GraphQL.Mutations;
using GraphQL.GraphQL.Queries;
using GraphQL.GraphQL.Subscriptions;
using GraphQL.GraphQL.Types;
using GraphQL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddMutationType(d => d.Name("Mutation"))
    .AddSubscriptionType(d => d.Name("Subscription"))

    .AddTypeExtension<BookQuery>()
    .AddTypeExtension<AuthorQuery>()
    .AddTypeExtension<AuthorMutation>()
    .AddTypeExtension<BookSubscription>()

    .AddType<BookType>()
    .AddType<AuthorType>()
    .AddInMemorySubscriptions()
    .AddProjections() // Cho phép sử dụng [UseProjection]
    .AddFiltering()  // Cho phép sử dụng [UseFiltering]
    .AddSorting();   // Cho phép sử dụng [UseSorting];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");
app.UseWebSockets();

app.Run();
