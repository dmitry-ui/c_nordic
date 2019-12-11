using System;
using System.Linq;

namespace EntityFrameWorkDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			using (ReminderItemDbContext context = new ReminderItemDbContext())
			{
				context.Add(
					new ReminderItem
					{
						Id = Guid.NewGuid(),
						Date = DateTimeOffset.Now,
						Message = "Test message",
						ContactId = "123456",
						Status = ReminderItemStatus.Awaiting
					});

				context.SaveChanges();

				var items = context.ReminderItems.ToList();

				foreach (var item in items)
				{
					Console.WriteLine(item.Id + " " + item.Message + " " + item.Date);

				}
			}

		}
	}
}
