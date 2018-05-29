using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using OCReady.Models;
using WebshopSkiiiiiii.Contexts;
using WebshopSkiiiiiii.Models;
using WebshopSkiiiiiii.Repositories;

namespace WebshopSkiiiiiii.MSSQLContext
{
	public class MSSQLUserContext : Database, IUserRepository
	{
		public bool Create(User user)
		{
			BillingContext bc = new BillingContext(new MSSQLBillingContext());
			bool state = false;
			string query = $"INSERT INTO dbo.User INSERT INTO (email, password,billingID) VALUES (@email,@password,@billingID)";
			try
			{
				if (OpenConnection())
				{
					using (SqlCommand cmd = new SqlCommand(query,Connection))
					{
						try
						{
							cmd.Parameters.AddWithValue("@email",user.Email);
							cmd.Parameters.AddWithValue("@password", user.Password);
							cmd.Parameters.AddWithValue("@billingID", bc.Create(user.Billing));
							cmd.ExecuteNonQuery();
							state = true;
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

			return state;

		}

		public bool Delete(int id)
		{
			bool state = false;
			string query = $"DELETE FROM dbo.User where Id = @id ";
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

			return state;
		}

		public int Login(User user)
		{
			int key = -1;
			string query = $"Select Id from dbo.User where email = @email AND password = @password";
			try
			{
				if (OpenConnection())
				{
					using (SqlCommand cmd = new SqlCommand(query, Connection))
					{
						try
						{
							cmd.Parameters.AddWithValue("@email", user.Email);
							cmd.Parameters.AddWithValue("@password", user.Password);
							key =Convert.ToInt32(cmd.ExecuteScalar());
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

			return key;
		}

		//Het gegeven Id is de primary key van de ingelogde User
		public List<Product> RefreshShoppingCart(int id)
		{
			//Selecteect alle product van product genaamd p
			// inner joined het product id in zowel product zelf als in de userProduct table
			// waar het account id uit de UserProduct tabel genaamd up gelijk is aan het meegegeven id
			List<Product> productList = new List<Product>();
			string query = $"SELECT FROM dbo.Product as p" +
			               $"inner join UserProduct as up on up.ProductID = p.Id" +
			               $"where up.AccountID = @id";
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
							using (SqlDataReader reader = cmd.ExecuteReader())
							{
								while (reader.Read())
								{
									try
									{
										int Id = Convert.ToInt32(reader["Id"]);
										string Name = reader["Name"].ToString();
										double Price = Convert.ToDouble(reader["Price"]);
										string describtion = reader["Describtion"].ToString();

										Product p = new Product(Id,Name,Price,describtion);
										productList.Add(p);
									}
									catch (SqlException e)
									{
										
										throw e;
									}
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

			return productList;
		}

		public bool Update(User user, int id)
		{
			bool state = false;
			string query = $"UPDATE FROM dbo.User SET email=@email, password = @password where Id = @id ";
			try
			{
				if (OpenConnection())
				{
					using (SqlCommand cmd = new SqlCommand(query, Connection))
					{
						try
						{
							cmd.Parameters.AddWithValue("@email", user.Email);
							cmd.Parameters.AddWithValue("@password", user.Password);
							cmd.Parameters.AddWithValue("@id", id);
							cmd.ExecuteNonQuery();
							state = true;
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

			return state;
		}
	}
}
