using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCReady.Models;
using WebshopSkiiiiiii.Models;
using WebshopSkiiiiiii.Repositories;

namespace WebshopSkiiiiiii.MSSQLContext
{
	public class MSSQLProductContext : Database, IProductRepository
	{
		public bool Create(Product product)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Product Detail(int id)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetAllProducts()
		{
			throw new NotImplementedException();
		}

		public bool Update(Product product, int id)
		{
			throw new NotImplementedException();
		}
	}
}
