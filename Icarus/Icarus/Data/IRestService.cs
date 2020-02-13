using System.Collections.Generic;
using System.Threading.Tasks;
using Icarus.Models;

namespace Icarus.Data
{
	public interface IRestService
	{
		Task<List<Fuel>> RefreshDataAsync ();

		//Task SaveTodoItemAsync (TodoItem item, bool isNewItem);

		//Task DeleteTodoItemAsync (string id);
	}
}
