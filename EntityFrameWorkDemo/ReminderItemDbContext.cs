using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkDemo
{
	public class ReminderItemDbContext : DbContext
	{
		private string _connectionString;

		public DbSet<ReminderItem> ReminderItems { get; set; }

		public ReminderItemDbContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public ReminderItemDbContext() : this (@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Reminder_Core;Integrated Security=true;")
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

	}
}
