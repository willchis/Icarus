using Icarus.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Icarus.Data
{
	public class GenerationMixManager
	{
		IRestService restService;

		public GenerationMixManager (IRestService service)
		{
			restService = service;
		}

		public Task<List<Fuel>> GetTasksAsync ()
		{
			return restService.GetFuelMixAsync ();	
		}

		//public Task SaveTaskAsync (TodoItem item, bool isNewItem = false)
		//{
		//	return restService.SaveTodoItemAsync (item, isNewItem);
		//}

		//public Task DeleteTaskAsync (TodoItem item)
		//{
		//	return restService.DeleteTodoItemAsync (item.ID);
		//}
	}
}
