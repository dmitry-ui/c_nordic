using Lesson12__2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson12__2
{
	class Passport : BaseDocument
	{
		public string Country { get; set; }
		public string PersonName { get; set; }
		public Passport(string country, string personname, string docnumber, DateTimeOffset issuedate): base("Passport", docnumber, issuedate)
		{
			Country = country;
			PersonName = personname;
		}
		public override string PropertiesString
		{
			get
			{
				return base.PropertiesString + $"\nCountry: {Country}\nPersonName: {PersonName}";
			}
		}
		public void ChangeIssueDate(DateTimeOffset newIssueDate)
		{
			IssueDate = newIssueDate;
		}
	}
}
