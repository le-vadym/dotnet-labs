using System.Data;
using System.Data.SqlClient;

namespace Lab1.Data;

internal sealed class LibraryDbContext : DbContext
{
    public DataTable Books => GetDataTable("SELECT * FROM Book;");
    public DataTable Reader => GetDataTable("SELECT * FROM Reader;");
    public DataTable Address => GetDataTable("SELECT * FROM Address;");
    public DataTable BookBorrow => GetDataTable("SELECT * FROM BookBorrow;");

    public LibraryDbContext(string connectionString) : base(connectionString) { }

    private DataTable GetDataTable(string query)
    {
        SqlDataAdapter adapter = new(query, Connection);
        DataSet ds = new();
        adapter.Fill(ds);

        return ds.Tables[0];
    }
}
