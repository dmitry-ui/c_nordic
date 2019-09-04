using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson12
{
	class BaseDocument
	{
		public string DocName { get; set; }
		public string DocNumber { get; set; }
		public DateTimeOffset IssueDate { get; set; }
		public string PropertiesString
		{
			get
			{
				return $"DocName: {DocName} \nDocNumber: {DocNumber}\nIssueDate: {IssueDate}";
			}
		}

	}
}
