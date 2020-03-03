using System;
using System.Collections.Generic;

namespace Models
{
    public class CityCreateModel
    {
        public string Name { get; set; }
        public string description { get; set; }
        public int NumberOfPintsOfInterest { get; set; }
    }

    public class CityGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public int NumberOfPintsOfInterest { get; set; }
    }

    public interface IStorageOperations
    {
        Dictionary<int, CityGetModel> GetAllCities();
        CityGetModel GetCityById(int idn);
        bool isPrezent(int idn);
        CityGetModel AddCity(CityCreateModel newCity);
        int GetFreeId();
        CityGetModel UpdateCity(int id, CityGetModel cityGetModel);
        bool DeleteCity(int id);
    }

}
