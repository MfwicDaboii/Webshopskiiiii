using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopSkiiiiiii.Models;
using WebshopSkiiiiiii.Repositories;

namespace WebshopSkiiiiiii.Contexts
{
	public class ProductContext : IProductRepository
	{
		private readonly IProductRepository Context;

		public ProductContext(IProductRepository context)
		{
			Context = context;
		}
		public bool Create(Product product)
		{
			return Context.Create(product);
		}

		public bool Delete(int id)
		{
			return Context.Delete(id);
		}

		public Product Detail(int id)
		{
			return Context.Detail(id);
		}

		public List<Product> GetAllProducts()
		{
			return Context.GetAllProducts();
		}

		public bool Update(Product product, int id)
		{
			return Context.Update(product, id);
		}
	}
}
