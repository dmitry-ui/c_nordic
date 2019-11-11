using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Models;

namespace Reminder.Storage.WebApi.Controllers
{
    [ApiController]
    [Route("api/reminders")]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderStorage _reminderStorage;

        public RemindersController(IReminderStorage reminderStorage)
        {
            _reminderStorage = reminderStorage;
        }

        [HttpPost]
        public IActionResult Add([FromBody] ReminderItemAddModel model)
        {
            if (model == null && !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reminderItem = model.ConvertToReminderItem();
            _reminderStorage.Add(reminderItem);

            return Created(
                    $"api/reminders/{reminderItem.Id}",
                    new ReminderItemGetModel(reminderItem));
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            //if (id == default(Guid))
            //{
            //    ModelState.AddModelError("id", "ID должен быть GUID");
            //    return BadRequest(ModelState);
            //}

            ReminderItem reminderItem = _reminderStorage.Get(id);
            if (reminderItem == null)
                return NotFound();

            return Ok(new ReminderItemGetModel(reminderItem));
        }

        [HttpGet]
        public IActionResult Get([FromQuery(Name = "[filter]status")]ReminderItemStatus status)
        {
            List<ReminderItem> reminderItems = _reminderStorage.Get(status);
            List<ReminderItemGetModel> reminderItemGetModels =
                reminderItems
                    .Select(x => new ReminderItemGetModel(x))
                    .ToList();
            return Ok(reminderItemGetModels);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(Guid id, [FromBody] ReminderItemUpdateModel model)
        {
            ReminderItem reminderItem = _reminderStorage.Get(id);

            if (reminderItem == null)
                return NotFound();

            if (model == null && !ModelState.IsValid)
                return BadRequest(ModelState);

            _reminderStorage.Update(id, model.Status);
            return NoContent();

        }




    }

}
