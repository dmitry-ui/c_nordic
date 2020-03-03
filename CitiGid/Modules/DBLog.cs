using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiGid.Modules
{
    class DBLog
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //сформируем объект - запрос в СитиГид из строки 
        public CitiGigRequest GetCitiGidRequest(string DBMessage)
        {
            int DBindexOfCharStart;
            int DBindexOfCharFinish;
            string DBRequest;
            string DBRequestRes;
            string DBsubStrStart = "{\\\"accessKey\\\":";
            //string DBsubStrFinish = "\"}]";

            string DBMessageTrim = DBMessage.Trim();
            DBindexOfCharStart = DBMessageTrim.IndexOf(DBsubStrStart);
            //DBindexOfCharFinish = DBMessage.IndexOf(DBsubStrFinish);
            DBRequest = DBMessageTrim.Substring(DBindexOfCharStart, DBMessageTrim.Length - DBindexOfCharStart -3);
            DBRequestRes = DBRequest.Replace("\\\"", "\"");
            return JsonConvert.DeserializeObject<CitiGigRequest>(DBRequestRes);
        }

        //получим объект равный одной строке лога запроса в СитиГид
        public DBString GetString(int id)
        {
            string sqlExpressionGetString = "select Id, HostName, Pid, Date, Thread, Logger, Level, " +
                                            "Message, Exception from [dbo].[GisCityGidLog] where Id =" + id;
            DBString dBString = new DBString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpressionGetString, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        dBString.Id = (int)reader.GetValue(0);
                        dBString.HostName = (string)reader.GetValue(1);
                        dBString.Pid = (string)reader.GetValue(2);
                        dBString.Date = (DateTime)reader.GetValue(3);
                        dBString.Thread = (string)reader.GetValue(4);
                        dBString.Logger = (string)reader.GetValue(5);
                        dBString.Level = (string)reader.GetValue(6);
                        dBString.Message = (string)reader.GetValue(7);
                        dBString.citiGigRequest = GetCitiGidRequest((string)reader.GetValue(7));

                        if (!(reader.GetValue(8) == DBNull.Value))
                            dBString.Exception = (string)reader.GetValue(8);
                    }
                }
                reader.Close();
            }

            return dBString;
        }

        //запишем распарсенную строку в таблицу распарсенных запросов
        public void SetCitiGidRequestParsed(DBString dBString)
        {
            string sqlExpression = $"SET IDENTITY_INSERT dbo.GisCityGidLog_Requests_Parsed ON " +
                $"INSERT INTO GisCityGidLog_Requests_Parsed ([Id],[HostName],[Pid],[Date],[Thread],[Logger],[Level],[Message],[Exception]" +
                $",[AccessKey],[GetPoints],[Type],[AllowYards],[AllowSideWays],[AllowGroundRoads],[AllowPaidRoads]" +
                $",[UseLimitsUpd],[UseForecast],[UseJams],[latitude1],[longitude1],[latitude2],[longitude2])" +
                $" VALUES  ({dBString.Id},'{dBString.HostName}','{dBString.Pid}','{dBString.Date.ToString("yyyy-MM-dd HH:mm:ss")}','{dBString.Thread}'," +
                $"'{dBString.Logger}','{dBString.Level}','{dBString.Message}','{dBString.Exception}'," +
                $"'{dBString.citiGigRequest.accessKey}','{dBString.citiGigRequest.getPoints}','{dBString.citiGigRequest.parameters.type}'," +
                $"'{dBString.citiGigRequest.parameters.allowYards}','{dBString.citiGigRequest.parameters.allowSideWays}'," +
                $"'{dBString.citiGigRequest.parameters.allowGroundRoads}','{dBString.citiGigRequest.parameters.allowPaidRoads}'," +
                $"'{dBString.citiGigRequest.parameters.useLimitsUpd}','{dBString.citiGigRequest.parameters.useForecast}'," +
                $"'{dBString.citiGigRequest.parameters.useJams}','{dBString.citiGigRequest.routes[0].points[0].latitude}'," +
                $"'{dBString.citiGigRequest.routes[0].points[0].longitude}','{dBString.citiGigRequest.routes[0].points[1].latitude}'," +
                $"'{dBString.citiGigRequest.routes[0].points[1].longitude}') " +
                $" SET IDENTITY_INSERT dbo.GisCityGidLog_Requests_Parsed OFF";
            //Console.WriteLine(sqlExpression);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
            }
        }

        //запишем диапазон строк запросов в распарсенную таблицу
        public void WriteToParsedTable(int minId, int maxId)
        {
            //получим список id - для парсинга
            List<int> Ids = new List<int>();
            string sqlExpression = $"select Id from GisCityGidLog where Message like '>>%' and Id between {minId} and {maxId}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Ids.Add((int)reader.GetValue(0));
                    }
                }
                reader.Close();
            }

            //записываем в распарсенную таблицу
            foreach (int id in Ids)
            {
                DBString dBString = GetString(id);
                SetCitiGidRequestParsed(dBString);
            }
        }

        //сформируем объект - ответ от СитиГида из строки
        public CityGidResponse GetCitiGidResponse(string DBMessage)
        {
            int DBindexOfCharStart;
            int DBindexOfCharFinish;
            string DBResponse;
            string DBResponseRes;
            string DBsubStrStart = "{\\\"type\\\":";
            //string DBsubStrFinish = "\"\r\n";
            string DBMessageTrim = DBMessage.Trim();
            DBindexOfCharStart = DBMessageTrim.IndexOf(DBsubStrStart);
            //DBindexOfCharFinish = DBMessageTrim.IndexOf(DBsubStrFinish);
            DBResponse = DBMessageTrim.Substring(DBindexOfCharStart, DBMessageTrim.Length - DBindexOfCharStart - 1);
            DBResponseRes = DBResponse.Replace("\\\"", "\"");
            return JsonConvert.DeserializeObject<CityGidResponse>(DBResponseRes);
        }

        //получим объект равный одной строке лога ответа из СитиГид
        public DBStringResponse GetStringResponse(int id)
        {
            string sqlExpressionGetString = "select Id, HostName, Pid, Date, Thread, Logger, Level, " +
                                            "Message, Exception from [dbo].[GisCityGidLog] where Id =" + id;
            DBStringResponse dBString = new DBStringResponse();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpressionGetString, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        dBString.Id = (int)reader.GetValue(0);
                        dBString.HostName = (string)reader.GetValue(1);
                        dBString.Pid = (string)reader.GetValue(2);
                        dBString.Date = (DateTime)reader.GetValue(3);
                        dBString.Thread = (string)reader.GetValue(4);
                        dBString.Logger = (string)reader.GetValue(5);
                        dBString.Level = (string)reader.GetValue(6);
                        dBString.Message = (string)reader.GetValue(7);
                        dBString.CityGidResponse = GetCitiGidResponse((string)reader.GetValue(7));

                        if (!(reader.GetValue(8) == DBNull.Value))
                            dBString.Exception = (string)reader.GetValue(8);
                    }
                }
                reader.Close();
            }

            return dBString;
        }

        //запишем распарсенную строку в таблицу распарсенных ответов
        public void SetCitiGidResponseParsed(DBStringResponse dBString)
        {
            string sqlExpression = $"SET IDENTITY_INSERT dbo.GisCityGidLog_Response_Parsed ON " +
               $"INSERT INTO GisCityGidLog_Response_Parsed ([Id],[HostName],[Pid],[Date],[Thread],[Logger],[Level],[Message],[Exception]" +
               $",[CityGidResponseType],[ErrorMessage],[FeatureType1],[GeometryType1],[GeometryCoordinates1],TotalTime1,TotalDistance1" +
               $",[GetPoints1],[Result1],[ZoneIntersections1],[PointsOrder1],[PointsStartIndexes1])" +
               $" VALUES  ({dBString.Id},'{dBString.HostName}','{dBString.Pid}','{dBString.Date.ToString("yyyy-MM-dd HH:mm:ss")}','{dBString.Thread}'," +
               $"'{dBString.Logger}','{dBString.Level}','{dBString.Message}','{dBString.Exception}'," +
               $"'{dBString.CityGidResponse.Type}','{dBString.CityGidResponse.ErrorMessage}','{dBString.CityGidResponse.Features[0].Type}'," +
               $"'{dBString.CityGidResponse.Features[0].Geometry.Type}','{dBString.CityGidResponse.Features[0].Geometry.Coordinates}'," +
               $"'{dBString.CityGidResponse.Features[0].Properties.TotalTime}','{dBString.CityGidResponse.Features[0].Properties.TotalDistance}'," +
               $"'{dBString.CityGidResponse.Features[0].Properties.GetPoints}','{dBString.CityGidResponse.Features[0].Properties.Result}'," +
               $"'{dBString.CityGidResponse.Features[0].ZoneIntersections}','{dBString.CityGidResponse.Features[0].PointsOrder}'," +
               $"'{dBString.CityGidResponse.Features[0].PointsStartIndexes}')" +
               $" SET IDENTITY_INSERT dbo.GisCityGidLog_Response_Parsed OFF";
            //Console.WriteLine(sqlExpression);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
            }
        }

        //запишем диапазон строк ответов в таблицу
        public void WriteResponsesToParsedTable(int minId, int maxId)
        {
            //получим список id - для парсинга
            List<int> Ids = new List<int>();
            string sqlExpression = $"select Id from GisCityGidLog where Message like '<<%' and Id between {minId} and {maxId}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Ids.Add((int)reader.GetValue(0));
                    }
                }
                reader.Close();
            }

            //записываем в распарсенную таблицу
            foreach (int id in Ids)
            {
                DBStringResponse dBString = GetStringResponse(id);
                SetCitiGidResponseParsed(dBString);
            }
        }

        //распарсим диапазон строк запросов и ответов
        public void WriteParsedTable(int minId, int maxId)
        {
            WriteToParsedTable(minId, maxId);
            WriteResponsesToParsedTable(minId, maxId);
        }
    }
}





