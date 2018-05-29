using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopSkiiiiiii.Models
{
    public class Product
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }

		public string Describtion { get; set; }

	    public Product()
	    {
	    }

	    public Product(string name, double price, string describtion)
	    {
		    Name = name;
		    Price = price;
		    Describtion = describtion;
	    }

	    public Product(int id, string name, double price, string describtion)
	    {
		    Id = id;
		    Name = name;
		    Price = price;
		    Describtion = describtion;
	    }
    }
}
