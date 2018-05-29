using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopSkiiiiiii.Models;
using WebshopSkiiiiiii.Repositories;

namespace WebshopSkiiiiiii.Contexts
{
	public class UserContext : IUserRepository
	{
		private readonly IUserRepository Context;

		public UserContext(IUserRepository context)
		{
			Context = context;	
		}
		public bool Create(User user)
		{
			return Context.Create(user);
		}

		public bool Delete(int id)
		{
			return Context.Delete(id);
		}

		public int Login(User user)
		{
			return Context.Login(user);
		}

		public List<Product> RefreshShoppingCart(int id)
		{
			return Context.RefreshShoppingCart(id);
		}

		public bool Update(User user, int id)
		{
			return Context.Update(user, id);
		}
	}
}
