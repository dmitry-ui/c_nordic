using ASPNETProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETProject.DataStore
{
	public class CitiesDataStore
	{
		//синглтон
		static CitiesDataStore _citiesDataStore;
		public  List<City> Cities { get; }

		private CitiesDataStore()
		{
			Cities = new List<City>
			{
				new City
				{
					Id=1,
					Name = "Moscow",
					Description = " описание",
					NumbersOfPointsOfInterest = 100
				},
				new City
				{
					Id=2,
					Name = "Volgograd",
					Description = "Описание",
					NumbersOfPointsOfInterest = 200
				}
			};
		}

		public static CitiesDataStore GetInstance()
		{
			if (_citiesDataStore == null)
				_citiesDataStore = new CitiesDataStore();
				return _citiesDataStore;
		}

		//лист городов


	}
}
