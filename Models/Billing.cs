using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopSkiiiiiii.Models
{
    public class Billing
    {
	    public int Id { get; set; }
	    public string Country { get; set; }
	    public string Zipcode { get; set; }
	    public string City { get; set; }
	    public string Street { get; set; }
	    public int Number { get; set; }
	    public string Addition { get; set; }

	    public Billing()
	    {

	    }
	    public Billing(int id, string country, string zipcode, string city, string street, int number, string addition)
	    {
		    Id = id;
		    Country = country;
		    Zipcode = zipcode;
		    City = city;
		    Street = street;
		    Number = number;
		    Addition = addition;
	    }

	    public Billing(string country, string zipcode, string city, string street, int number, string addition)
	    {
		    Country = country;
		    Zipcode = zipcode;
		    City = city;
		    Street = street;
		    Number = number;
		    Addition = addition;
	    }
	}
}
