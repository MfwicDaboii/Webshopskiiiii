using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OCReady.Models
{
	public class Database
	{
		public SqlConnection Connection;
		public string Password;
		public string Uid;
		public string DB;
		public string Server;

		// opent de connectie 
		public bool OpenConnection()
		{
			Server = "mssql.fhict.local";
			DB = "dbi349918";
			Uid = "dbi349918";
			Password = "Wachtwoord007";
			string connectionString;
			connectionString = "SERVER=" + Server + ";" + "DATABASE=" +
			                   DB + ";" + "UID=" + Uid + ";" + "PASSWORD=" + Password + ";";

			Connection = new SqlConnection(connectionString);
			try
			{
				Connection.Open();
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;

			}
		}

		public bool CloseConnection()
		{
			bool state = false;
			try
			{
				Connection.Close();
				state = true;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
			return state;
		}

	}
}