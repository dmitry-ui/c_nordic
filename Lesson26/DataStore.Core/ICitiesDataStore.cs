using System.Collections.Generic;

namespace DataStore.Core
{
	public interface ICitiesDataStore
	{
		IDictionary<int, City> Cities { get; }
	}
}
