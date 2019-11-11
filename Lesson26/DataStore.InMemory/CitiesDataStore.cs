using DataStore.Core;
using System.Collections.Generic;

namespace DataStore.InMemory
{
	public class CitiesDataStore: ICitiesDataStore
	{
		public IDictionary<int, City> Cities { get; }

		public CitiesDataStore()
		{
			Cities = new Dictionary<int, City>();
		}
	}
}
