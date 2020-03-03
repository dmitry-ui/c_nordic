using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Storage
{
    
    public class StorageOperations : IStorageOperations
    {
        public string connectionString = "Data Source=;Initial Catalog=;Integrated Security=True;User Id = ; Password = ";

        public Dictionary<int, CityGetModel> GetAllCities()
        {
            Dictionary<int, CityGetModel> AllCities = new Dictionary<int, CityGetModel>();

            //создаем подключение к БД, данные берем из конфига 
            //string connectionString = ConfigurationManager.ConnectionStrings["Cities"].ConnectionString;
            string sqlExpression = "SELECT * FROM Cities";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        CityGetModel city = new CityGetModel();
                        city.Id = (int)reader.GetValue(0);
                        city.Name = (string)reader.GetValue(1);
                        city.description = (string)reader.GetValue(2);
                        city.NumberOfPintsOfInterest = (int)reader.GetValue(3);

                        AllCities.Add(city.Id, city);
                    }
                }
                reader.Close();
            }
            return AllCities;
        }

        public CityGetModel GetCityById(int idn)
        {
            CityGetModel city = new CityGetModel();
            //создаем подключение к БД, данные берем из конфига 
            //string connectionString = ConfigurationManager.ConnectionStrings["Cities"].ConnectionString;
            string sqlExpression = "select * from Cities where id =" + idn;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        city.Id = (int)reader.GetValue(0);
                        city.Name = (string)reader.GetValue(1);
                        city.description = (string)reader.GetValue(2);
                        city.NumberOfPintsOfInterest = (int)reader.GetValue(3);
                    }
                }
                reader.Close();
            }
            return city;
        }

        public bool isPrezent(int idn)
        {
            CityGetModel city = new CityGetModel();
            bool Result = false;
            //создаем подключение к БД, данные берем из конфига 
            //string connectionString = ConfigurationManager.ConnectionStrings["Cities"].ConnectionString;
            string sqlExpression = "select 1 from Cities where id =" + idn;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                    Result = true;
                reader.Close();
            }
            return Result;
        }

        public CityGetModel AddCity(CityCreateModel newCity)
        {
            int freeId = GetFreeId();
            string sqlExpression = $"INSERT INTO Cities (Id, Name, Description, NumberOfPointsOfInterest) " +
                                    $"VALUES ({freeId},'{newCity.Name}','{newCity.description}',{newCity.NumberOfPintsOfInterest})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();

                return GetCityById(freeId);
            }
        }

        public int GetFreeId()
        {
            string sqlExpression = $"select top 1 id+1 from Cities order by id desc";
            int freeID;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                freeID = (int)command.ExecuteScalar();
            }
            return freeID;
        }

        public CityGetModel UpdateCity(int id, CityGetModel City)
        {
            string sqlExpression = $"update Cities " +
                                    $"set Name ='{City.Name}'," +
                                    $"Description ='{City.description}'," +
                                    $"NumberOfPointsOfInterest = {City.NumberOfPintsOfInterest}" +
                                    $"where Id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();

                return GetCityById(City.Id);
            }

        }

        public bool DeleteCity(int id)
        {
            string sqlExpression = $"delete from  Cities " +
                                    $"where Id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();

                if (number == 1)
                    return true;
                return false;
            }
        }
    }
}
