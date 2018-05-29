using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebshopSkiiiiiii.Contexts;
using WebshopSkiiiiiii.Models;
using WebshopSkiiiiiii.MSSQLContext;

namespace WebshopSkiiiiiii.Controllers
{
	public class BillingController : Controller
	{
		BillingContext bc =new BillingContext(new MSSQLBillingContext());
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Detail(int id)
		{
			Billing billing = bc.Detail(id);

			return View(billing);
		}
	}
}