using Lab1.Data;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
string connectionString = configuration.GetConnectionString("DefaultConnection");

using LibraryDbContext dbContext = new(connectionString);
var booksTable = dbContext.Books.AsEnumerable();
var readersTable = dbContext.Reader.AsEnumerable();
var bookBorrowsTable = dbContext.BookBorrow.AsEnumerable();

var borrowedBooks = from reader in readersTable
                    join bookBorrow in bookBorrowsTable
                    on reader.Field<Guid>("Id") equals bookBorrow.Field<Guid>("ReaderId")
                    join book in booksTable on bookBorrow.Field<Guid>("BookId") equals book.Field<Guid>("Id")
                    group book by bookBorrow.Field<Guid>("ReaderId") into g
                    select new
                    {
                        FirstName = readersTable.First(r => (Guid)r.ItemArray[0] == g.Key)["FirstName"],
                        LastName = readersTable.First(r => (Guid)r.ItemArray[0] == g.Key)["LastName"],
                        Books = g.Select(b => b),
                    };

Console.OutputEncoding = Encoding.UTF8;
foreach (var borrowedBookInfo in borrowedBooks)
{
    Console.WriteLine($"{borrowedBookInfo.FirstName,-10} has {borrowedBookInfo.Books.Count()} books: ");
    foreach (var book in borrowedBookInfo.Books)
    {
        Console.WriteLine($"\t{book.Field<string>("Name")}");
    }
    Console.WriteLine();
}
