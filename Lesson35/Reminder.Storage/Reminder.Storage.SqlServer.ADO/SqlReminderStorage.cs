using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Reminder.Storage.Core;

namespace Reminder.Storage.SqlServer.ADO
{
	public class SqlReminderStorage : IReminderStorage
	{
		private string _connectionString;

		public SqlReminderStorage(string connectionString)
		{
			_connectionString = connectionString;
		}

		public Guid Add(DateTimeOffset date, string message, string contactId, ReminderItemStatus status)
		{
			using (var sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open();

				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.AddReminderItem";

				cmd.Parameters.AddWithValue("@contactId", contactId);
				cmd.Parameters.AddWithValue("@targetDate", date);
				cmd.Parameters.AddWithValue("@message", message);
				cmd.Parameters.AddWithValue("@statusId", (byte)status);

				return (Guid)cmd.ExecuteScalar();
			}

		}

		public ReminderItem Get(Guid id)
		{
			using (var sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open();

				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.GetReminderItemById";
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					//если строка есть и ее успешно прочитали
					if (reader.HasRows && reader.Read())
					{
						//Id, ContactId, TargetDate, Message, StatusId
						int IDIndex = reader.GetOrdinal("Id");
						int ContactIdIndex = reader.GetOrdinal("ContactId");
						int TargetDateIndex = reader.GetOrdinal("TargetDate");
						int MessageIndex = reader.GetOrdinal("Message");
						int StatusIdIndex = reader.GetOrdinal("StatusId");

						return new ReminderItem(reader.GetGuid(IDIndex),
									reader.GetDateTimeOffset(TargetDateIndex),
									reader.GetString(ContactIdIndex),
									reader.GetString(MessageIndex),
									(ReminderItemStatus)reader.GetByte(StatusIdIndex));
					}

					return null;

				}

			}
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			using (var sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open();

				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.GetReminderItemByStatus";
				cmd.Parameters.AddWithValue("@statusId", (byte)status);

				using (var reader = cmd.ExecuteReader())
				{
					var result = new List<ReminderItem>();

					while (reader.Read())
					{
						//Id, ContactId, TargetDate, Message, StatusId
						int IDIndex = reader.GetOrdinal("Id");
						int ContactIdIndex = reader.GetOrdinal("ContactId");
						int TargetDateIndex = reader.GetOrdinal("TargetDate");
						int MessageIndex = reader.GetOrdinal("Message");
						int StatusIdIndex = reader.GetOrdinal("StatusId");

						result.Add(new ReminderItem(reader.GetGuid(IDIndex),
									reader.GetDateTimeOffset(TargetDateIndex),
									reader.GetString(ContactIdIndex),
									reader.GetString(MessageIndex),
									(ReminderItemStatus)reader.GetByte(StatusIdIndex)));
					}
					return result;
				}
			}
		}

		public void Update(Guid id, ReminderItemStatus status)
		{
			//[UpdateReminderItemStatus]
			using (var sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open();

				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.UpdateReminderItemStatus";
				cmd.Parameters.AddWithValue("@id", id);
				cmd.Parameters.AddWithValue("@statusId", (byte)status);

				cmd.ExecuteNonQuery();
			}
		}
	}
}
