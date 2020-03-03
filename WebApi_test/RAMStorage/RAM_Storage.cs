using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Models;


namespace Storage
{
    public class CityDatastore
    {
        private static CityDatastore _cityDatastore;

        public Dictionary<int, CityGetModel> Cities = new Dictionary<int, CityGetModel>();

        private CityDatastore()
        {
            //пока заполним хранилище некоторыми значениями здесь
            CityGetModel city1 = new CityGetModel { Id = 1, Name = "Piter", description = "Здесь живет моя сестра", NumberOfPintsOfInterest = 100 };
            CityGetModel city2 = new CityGetModel { Id = 2, Name = "Rostov", description = "Здесь живет Вася", NumberOfPintsOfInterest = 99 };
            CityGetModel city3 = new CityGetModel { Id = 3, Name = "Taganrog", description = "Здесь учился я", NumberOfPintsOfInterest = 150 };
            Cities.Add(city1.Id, city1);
            Cities.Add(city2.Id, city2);
            Cities.Add(city3.Id, city3);
        }

        public static CityDatastore GetInstance()
        {
            if (_cityDatastore == null)
                _cityDatastore = new CityDatastore();

            return _cityDatastore;
        }
    }

    public class StorageOperations : IStorageOperations
    {
        public Dictionary<int, CityGetModel> GetAllCities()
        {
            CityDatastore cityDatastore = CityDatastore.GetInstance();

            return cityDatastore.Cities;
        }

        public CityGetModel GetCityById(int idn)
        {
            CityDatastore cityDatastore = CityDatastore.GetInstance();
            return cityDatastore.Cities[idn];
        }

        public bool isPrezent(int idn)
        {
            CityDatastore cityDatastore = CityDatastore.GetInstance();
            return cityDatastore.Cities.ContainsKey(idn);
        }

        public CityGetModel AddCity(CityCreateModel newCity)
        {
            var cityDatastore = CityDatastore.GetInstance();
            CityGetModel cityGetModel = new CityGetModel();
            int freeId = GetFreeId();

            cityGetModel.Id = freeId;
            cityGetModel.Name = newCity.Name;
            cityGetModel.description = newCity.description;
            cityGetModel.NumberOfPintsOfInterest = newCity.NumberOfPintsOfInterest;

            cityDatastore.Cities.Add(freeId, cityGetModel);
            return cityGetModel;
        }

        public int GetFreeId()
        {
            //получим свободный id как максимальный плюс 1
            var cityDatastore = CityDatastore.GetInstance();
            int freeID = cityDatastore.Cities.Keys.Max() + 1;

            return freeID;
        }

        public CityGetModel UpdateCity(int id, CityGetModel City)
        {
            var cityDatastore = CityDatastore.GetInstance();

            CityGetModel updatedCity = cityDatastore.Cities[id];
            updatedCity.Name = City.Name;
            updatedCity.description = City.description;
            updatedCity.NumberOfPintsOfInterest = City.NumberOfPintsOfInterest;

            return updatedCity;
        }

        public bool DeleteCity(int id)
        {
            var cityDatastore = CityDatastore.GetInstance();
            return cityDatastore.Cities.Remove(id);
        }

    }
}
