using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Controllers
{
	[ApiController]
	[Route("api/reminders")]
	public class RemindersController: ControllerBase
	{
		private readonly IReminderStorage _reminderStorage;

		public RemindersController(IReminderStorage reminderStorage)
		{
			_reminderStorage = reminderStorage;
		}

		[HttpPost]
		public IActionResult Add([FromBody]ReminderItemAddModel model)
		{
			if(model == null && !ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Guid id = _reminderStorage.Add(
				model.Date,
				model.Message,
				model.ContactId,
				model.Status);

			return Created(
				$"api/reminders/{id}",
				new ReminderItemGetModel
				{
					Id = id,
					Date = model.Date,
					Message = model.Message,
					ContactId = model.ContactId,
					Status = model.Status
				});
		}

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			ReminderItem reminderItem = _reminderStorage.Get(id);
			if(reminderItem == null)
			{
				return NotFound();
			}

			return Ok(new ReminderItemGetModel(reminderItem));
		}

		[HttpGet]
		public IActionResult Get([FromQuery(Name = "[filter]status")]ReminderItemStatus status)
		{
			List<ReminderItem> reminderItems = _reminderStorage.Get(status);
			List<ReminderItemGetModel> reminderItemGetModels = reminderItems
				.Select(x => new ReminderItemGetModel(x))
				.ToList();

			return Ok(reminderItemGetModels);
		}

		[HttpPatch("{id}")]
		public IActionResult Update(Guid id, [FromBody] ReminderItemUpdateModel model)
		{
			ReminderItem reminderItem = _reminderStorage.Get(id);
			if (reminderItem == null)
			{
				return NotFound();
			}

			if (model == null && !ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_reminderStorage.Update(id, model.Status);

			return NoContent();
		}
	}
}
