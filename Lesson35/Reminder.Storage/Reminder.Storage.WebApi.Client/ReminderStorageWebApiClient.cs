using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Client
{
	public class ReminderStorageWebApiClient : IReminderStorage
	{
		private readonly string _baseWebApiUrl;
		private HttpClient _httpClient;

		public ReminderStorageWebApiClient(string baseWebApiUrl)
		{
			_baseWebApiUrl = baseWebApiUrl; // http://localhost:5000/api/reminders
			_httpClient = HttpClientFactory.Create();
		}

		public Guid Add(
			DateTimeOffset date,
			string message,
			string contactId,
			ReminderItemStatus status)
		{
			// POST http://localhost:5000/api/reminders/ ReminderItemAddModel

			var model = new ReminderItemAddModel
			{
				Date = date,
				Message = message,
				ContactId = contactId,
				Status = status
			};

			string content = JsonConvert.SerializeObject(model);

			HttpResponseMessage response = SendRequest(
				_baseWebApiUrl,
				"POST",
				content);

			ThrowExceptionIfStatusCodeOtherThan(HttpStatusCode.Created, response);

			var body = response.Content.ReadAsStringAsync().Result;
			var getModel = JsonConvert.DeserializeObject<ReminderItemGetModel>(body);
			return getModel.Id;
		}

		public ReminderItem Get(Guid id)
		{
			HttpResponseMessage response = SendRequest(
				_baseWebApiUrl + $"/{id}",
				"GET",
				null);

			if (response.StatusCode == HttpStatusCode.NotFound)
				return null;

			ThrowExceptionIfStatusCodeOtherThan(HttpStatusCode.OK, response);

			string content = response.Content.ReadAsStringAsync().Result;
			var model = JsonConvert.DeserializeObject<ReminderItemGetModel>(content);

			return new ReminderItem(
				model.Id,
				model.Date,
				model.Message,
				model.ContactId,
				model.Status);
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			HttpResponseMessage response = SendRequest(
				_baseWebApiUrl + $"?[filter]status={status}",
				"GET",
				null);

			ThrowExceptionIfStatusCodeOtherThan(HttpStatusCode.OK, response);

			string content = response.Content.ReadAsStringAsync().Result;
			var models = JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(content);

			var result = models
				.Select(model => new ReminderItem(
					model.Id,
					model.Date,
					model.Message,
					model.ContactId,
					model.Status))
				.ToList();

			return result;
		}

		public void Update(Guid id, ReminderItemStatus status)
		{
			// PATCH http://localhost:5000/api/reminders/id ReminderItemUpdateModel

			var model = new ReminderItemUpdateModel { Status = status };
			string content = JsonConvert.SerializeObject(model);

			HttpResponseMessage response = SendRequest(
				_baseWebApiUrl + $"/{id}",
				"PATCH",
				content);

			ThrowExceptionIfStatusCodeOtherThan(HttpStatusCode.NoContent, response);
		}

		private HttpResponseMessage SendRequest(
			string requestUri,
			string method,
			string content)
		{
			// prepare request

			HttpMethod httpMethod = new HttpMethod(method);
			var request = new HttpRequestMessage(
				httpMethod,
				requestUri);

			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

			if (content != null)
			{
				request.Content = new StringContent(
					content,
					Encoding.UTF8,
					"application/json");
			}

			// send request

			return _httpClient.SendAsync(request).Result;
		}

		private static void ThrowExceptionIfStatusCodeOtherThan(
			HttpStatusCode httpStatusCode,
			HttpResponseMessage httpResponseMessage)
		{
			if (httpResponseMessage.StatusCode != httpStatusCode)
			{
				throw new Exception(
					$"Status code: {httpResponseMessage.StatusCode}.\n" +
					$"Content:\n{httpResponseMessage.Content.ReadAsStringAsync().Result}");
			}
		}
	}
}
