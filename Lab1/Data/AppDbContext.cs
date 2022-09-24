using System.Data;
using System.Data.SqlClient;

namespace Lab1.Data;

internal sealed class LibraryDbContext : DbContext
{
    public DataTable Books => GetDataTable("Book");
    public DataTable Reader => GetDataTable("Reader");
    public DataTable Address => GetDataTable("Address");
    public DataTable BookBorrow => GetDataTable("BookBorrow");

    public LibraryDbContext(string connectionString) : base(connectionString) { }

    private DataTable GetDataTable(string tableName)
    {
        SqlCommand command = new($"SELECT * FROM {tableName};", Connection);

        SqlDataAdapter adapter = new(command);
        DataSet ds = new();
        adapter.Fill(ds);

        return ds.Tables[0];
    }
}
