using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Storage.WebApi.Models
{
    public class ReminderItemUpdateModel
    {
        [Required]
        public ReminderItemStatus Status { get; set; }
          
    }
}
