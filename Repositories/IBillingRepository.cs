using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopSkiiiiiii.Models;

namespace WebshopSkiiiiiii.Repositories
{
	public interface IBillingRepository
	{
		int Create(Billing billing);

		bool Delete(int id);

		bool Update(Billing billing, int id);

		Billing Detail(int id);
	}
}
