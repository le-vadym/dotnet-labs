using System.Data;
using System.Data.SqlClient;

namespace Lab1.Data;

internal class DbContext : IDisposable
{
	private bool _disposed;
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
		if (_disposed)
		{
			return;
		}

		_conn.Dispose();
		_disposed = true;
	}
}
