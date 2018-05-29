using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopSkiiiiiii.Models;
using WebshopSkiiiiiii.Repositories;

namespace WebshopSkiiiiiii.Contexts
{
	public class BillingContext : IBillingRepository
	{

		private readonly IBillingRepository Context;

		public BillingContext(IBillingRepository context)
		{
			Context = context;
		}
		public int Create(Billing billing)
		{
			return Context.Create(billing);
		}

		public bool Delete(int id)
		{
			return Context.Delete(id);
		}

		public Billing Detail(int id)
		{
			return Context.Detail(id);
		}

		public bool Update(Billing billing, int id)
		{
			return Context.Update(billing, id);
		}
	}
}
