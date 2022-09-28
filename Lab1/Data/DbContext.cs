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
<<<<<<< HEAD
		_conn.Close();
=======
>>>>>>> 6c14244c1452a56f1a7006d7a111d98e111e2581
		_conn.Dispose();
	}
}
