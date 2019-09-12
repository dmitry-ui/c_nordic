using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson14
{
	class ErrorList : IDisposable, IEnumerable<string>
	{
		public static string OutputPrefixFormat
		{
			get;set;
		}

		static ErrorList()
			{
				OutputPrefixFormat = "MMMM d, yyyy (h:mm tt)";
			}

		public string Category { get; }

		private List<string> _errors;

		public ErrorList(string category)
		{
			Category = category;
			_errors = new List<string>();
		}

		public void Add(string ErrorMessage)
		{
			_errors.Add("ErrorMessage");
		}

		public void Dispose()
		{
			_errors.Clear();
			_errors = null;
		}

		public IEnumerator<string> GetEnumerator()
		{
			return _errors.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void WriteToConsole()
		{
			foreach (string error in _errors)
			{
				//Console.WriteLine($"{errorList.Category}:{error}");

				Console.WriteLine(DateTime.Now.ToString(OutputPrefixFormat) + Category + ":" + error);
			}
		}
	}
}
