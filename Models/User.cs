using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopSkiiiiiii.Models
{
    public class User
    {
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

	    private List<Product> Cart { get; set; }
		public Billing Billing { get; set; }

	    public User()
	    {
	    }

	    public User(string email, string password, Billing billing)
	    {
		    Email = email;
		    Password = password;
		    Billing = billing;
			Cart = new List<Product>();
	    }
    }
}
