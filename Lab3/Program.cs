using Lab3.Models;
using Lab3.Repositories;
using MongoDB.Driver;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton(s =>
{
    var mongoClient = s.GetRequiredService<IMongoClient>();
    return mongoClient.GetDatabase(builder.Configuration.GetSection("LibraryDatabase")["Name"]);
});
builder.Services.AddSingleton(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

app.MapGet("/", async (HttpContext context) =>
{
    var bookBorrowRepository = app.Services.GetRequiredService<IRepository<BookBorrow>>();
    var bookBorrows = (await bookBorrowRepository.GetAllAsync()).GroupBy(b => new { b.Reader.FirstName, b.Reader.LastName });

    context.Response.Headers.ContentType = new Microsoft.Extensions.Primitives.StringValues("text/html; charset=UTF-8");

    var bookBorrowsString = new StringBuilder();
    bookBorrowsString.AppendLine("<img src=\"/img/logo.svg\" alt=\"logo\" width='100' height='100'/>");
    foreach (var bookBorrow in bookBorrows)
    {
        bookBorrowsString.AppendLine("<div>");
        bookBorrowsString.AppendLine($"<h2>{bookBorrow.Key.FirstName} {bookBorrow.Key.LastName}</h2>");
        bookBorrowsString.AppendLine($"<p>Has borrowed {bookBorrow.Count()} book(s)</p>");
        bookBorrowsString.AppendLine("<ul>");
        foreach (var bookInfo in bookBorrow)
        {
            bookBorrowsString.AppendLine($"<li>{bookInfo.Book.Name}</li>");
        }
        bookBorrowsString.AppendLine("</ul>");
        bookBorrowsString.AppendLine("</div>");
    }

    await context.Response.WriteAsync(text: "<html><body>" +
        "<h1>Library</h1>" +
        bookBorrowsString.ToString() +
        "<body></html>");
});

app.UseStaticFiles();

app.Run();
