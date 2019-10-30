using L22_C01_empty_asp_net_core_app.Models;
using System.Collections.Generic;

namespace L22_C01_empty_asp_net_core_app.DataStore
{
	public class CitiesDataStore
	{
		private static CitiesDataStore _citiesDataStore;

		public Dictionary<int, City> Cities { get; }

		private CitiesDataStore()
		{
			Cities = new Dictionary<int, City>
			{
				{
					1,
					new City
					{
						Id = 1,
						Name = "Moscow",
						Description = "This is my favorite city!",
						NumberOfPointsOfInterest = 100
					}
				},
				{
					2,
					new City
					{
						Id = 2,
						Name = "New York",
						Description = "I ❤ NY",
						NumberOfPointsOfInterest = 99
					}
				}
			};
		}

		public static CitiesDataStore GetInstance()
		{
			if (_citiesDataStore == null)
				_citiesDataStore = new CitiesDataStore();

			return _citiesDataStore;
		}
	}
}
