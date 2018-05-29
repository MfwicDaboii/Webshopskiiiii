using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopSkiiiiiii.Models;

namespace WebshopSkiiiiiii.Repositories
{
    public interface IUserRepository
    {
		//De int die hij teruggeeft is de primarykey van de User
	    int Login(User user);

	    bool Create(User user);

		//de int Id in de parameters staat voor de primarykey van de User
	    bool Update(User user, int id);

	    bool Delete(int id);

	    List<Product> RefreshShoppingCart(int id);
    }
}
