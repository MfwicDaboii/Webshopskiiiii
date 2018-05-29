using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using OCReady.Models;
using WebshopSkiiiiiii.Models;
using WebshopSkiiiiiii.Repositories;

namespace WebshopSkiiiiiii.MSSQLContext
{
	public class MSSQLBillingContext : Database, IBillingRepository
	{
		public int Create(Billing billing)
		{
			//Scope_Identity zorgt ervoor dat hij na de insert gelijk het id teruggeeft
			string query = $"INSERT INTO dbo.Billing (Country,Zipcode,City,Street,Number,Addition)" +
			               $" Values (@country,@zipcode,@city,@street,@number,@addition)" + "SELECT SCOPE_IDENTITY()";
			int state = -1;
			try
			{
				if (OpenConnection())
				{
					using (SqlCommand cmd = new SqlCommand(query, Connection))
					{
						try
						{
							cmd.Parameters.AddWithValue("@country", billing.Country);
							cmd.Parameters.AddWithValue("@zipcode", billing.Zipcode);
							cmd.Parameters.AddWithValue("@city", billing.City);
							cmd.Parameters.AddWithValue("@street", billing.Street);
							cmd.Parameters.AddWithValue("@number", billing.Number);
							if (billing.Addition == null)
							{
								billing.Addition = " ";
							}
							cmd.Parameters.AddWithValue("@addition", billing.Addition);
							state = Convert.ToInt32(cmd.ExecuteScalar());

						}
						catch (SqlException ex)
						{
							Console.WriteLine(ex);
							throw;
						}

					}
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			return state;
		}

		public bool Delete(int id)
		{
			string query = $"DELETE FROM dbo.Billing where Id = @id";
			bool state = false;
			try
			{
				if (OpenConnection())
				{
					using (SqlCommand cmd = new SqlCommand(query, Connection))
					{
						try
						{
							cmd.Parameters.AddWithValue("@id", id);
							cmd.ExecuteNonQuery();
							state = true;
						}
						catch (SqlException ex)
						{
							Console.WriteLine(ex);
							throw;
						}

					}
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			return state;
		}

		public Billing Detail(int id)
		{
			Billing billing = null;
			string query = $"SELECT * FROM dbo.Billing where Id = @id";
			try
			{
				if (OpenConnection())
				{
					using (SqlCommand cmd = new SqlCommand(query,Connection))
					{
						try
						{
							cmd.Parameters.AddWithValue("@id", id);
							cmd.ExecuteNonQuery();

							using (SqlDataReader reader = cmd.ExecuteReader())
							{
								while (reader.Read())
								{
									int Id= Convert.ToInt32(reader["Id"]);
									string Country = reader["Country"].ToString();
									string Zipcode = reader["Zipcode"].ToString();
									string City = reader["City"].ToString();
									string Street = reader["Street"].ToString();
									int Number = Convert.ToInt32(reader["Number"]);
									string Addition= reader["Addition"].ToString();
									billing = new Billing(Id,Country,Zipcode,City,Street,Number,Addition);
								}
							}
						}
						catch (SqlException e)
						{
							throw e;
						}
						

						
					}
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			return billing;
		}

		public bool Update(Billing billing, int id)
		{
			
			string query = $"UPDATE dbo.Billing set Country = @country AND Zipcode = @zipcode AND City = @city" +
			               $"AND Street= @street AND Number = @number AND Addition = @addition" +
			               $"where Id = @id ";

			bool state = false;
			try
			{
				if (OpenConnection())
				{
					using (SqlCommand cmd = new SqlCommand(query, Connection))
					{
						try
						{
							cmd.Parameters.AddWithValue("@id", id);
							cmd.Parameters.AddWithValue("@country", billing.Country);
							cmd.Parameters.AddWithValue("@zipcode", billing.Zipcode);
							cmd.Parameters.AddWithValue("@city", billing.City);
							cmd.Parameters.AddWithValue("@street", billing.Street);
							cmd.Parameters.AddWithValue("@number", billing.Number);
							cmd.Parameters.AddWithValue("@addition", billing.Addition);
							cmd.ExecuteNonQuery();
							state = true;

						}
						catch (SqlException ex)
						{
							Console.WriteLine(ex);
							throw;
						}

					}
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			return state;
		}
	}
}
