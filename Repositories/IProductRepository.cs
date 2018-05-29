using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopSkiiiiiii.Models;

namespace WebshopSkiiiiiii.Repositories
{
	public interface IProductRepository
    {
	    bool Create(Product product);

	    bool Delete(int id);

	    bool Update(Product product, int id);

	    List<Product> GetAllProducts();
	    Product Detail(int id);

    }
}
