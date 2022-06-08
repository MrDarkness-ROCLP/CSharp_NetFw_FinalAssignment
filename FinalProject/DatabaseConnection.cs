using System;
using System.Data;
using System.Data.SqlClient;

namespace FinalProject
{
	internal class DatabaseConnection
	{
		private string connectionString;
		public DatabaseConnection()
		{
			connectionString = "Data Source=localhost; Initial Catalog=FINAL; User ID=SA; Password=SayaOtaku;";
		}

		public DatabaseConnection(string connnectionString)
		{
			this.connectionString = connnectionString;
		}

		// Insert, Update, Delete (Not getting data)
		public bool ExecuteNonDataQuery(string query)
		{
			SqlConnection conn = new SqlConnection(connectionString);
			SqlCommand command;
			try
			{
				conn.Open();
				command = new SqlCommand(query, conn);
				command.ExecuteNonQuery();
				command.Dispose();
				conn.Close();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return false;
			}
		}

		// Get data from database
		public DataTable ExecuteDataQuery(string query)
		{
			SqlConnection conn = new SqlConnection(connectionString);
			SqlCommand command;
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				command = new SqlCommand(query, conn);
				dt.Load(command.ExecuteReader());
				command.Dispose();
				conn.Close();
				return dt;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return null;
			}
		}
	}
}