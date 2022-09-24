using System.Data;
using System.Data.SqlClient;

namespace Lab1.Data;

internal class DbContext : IDisposable
{
	private readonly SqlConnection _conn;

	public SqlConnection Connection
	{
		get
		{
			if (_conn.State != ConnectionState.Open)
			{
				_conn.Open();
			}

			return _conn;
		}
	}

	public DbContext(string connectionString)
	{
		_conn = new SqlConnection(connectionString: connectionString);
	}

	public void Dispose()
	{
		_conn.Close();
		_conn.Dispose();
	}
}
