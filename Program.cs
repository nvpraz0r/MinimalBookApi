var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var books = new List<Book>
{
    new Book {Id = 1, Title = "Warcraft: Lord of the Clans", Author = "Christie Golden"},
    new Book {Id = 2, Title = "The Hobbit", Author = "J. R. R. Tolkien"},
    new Book {Id = 3, Title = "Jurassic Park", Author = "Michael Crichton"},
    new Book {Id = 4, Title = "Game of Thrones", Author = "George R. R. Martin"},
};

app.MapGet("/book", () =>
{
    return books;
});

app.Run();

class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}