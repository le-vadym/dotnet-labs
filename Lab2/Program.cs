using Lab2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
var connectionString = configuration.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
optionsBuilder.UseSqlServer(connectionString);

var context = new LibraryDbContext(optionsBuilder.Options);
await context.Database.EnsureCreatedAsync();

var borrowedBookInfos = context.BookBorrows
    .Include(b => b.Reader)
    .Include(b => b.Book)
    .ToList()
    .GroupBy(b => b.Reader);

Console.OutputEncoding = Encoding.UTF8;
foreach (var borrowedBookInfo in borrowedBookInfos)
{
    Console.WriteLine($"{borrowedBookInfo.Key.FirstName,-10} has {borrowedBookInfo.Count()} books: ");
    foreach (var info in borrowedBookInfo)
    {
        Console.WriteLine($"\t{info.Book.Name}");
    }
    Console.WriteLine();
}
