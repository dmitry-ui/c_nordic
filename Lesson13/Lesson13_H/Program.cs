using System;

namespace Lesson13_H
{
	class Program
	{
		static void Main(string[] args)
		{
			Logs lg = new Logs(Logs.TypeMessege.info);
			Console.WriteLine(lg.LogMessage("Все ОК"));

			Logs lg1 = new Logs(Logs.TypeMessege.error);
			Console.WriteLine(lg1.LogMessage("Error"));

			Logs lg2 = new Logs(Logs.TypeMessege.warning);
			Console.WriteLine(lg2.LogMessage("Все почти ОК"));

			ConsoleLogs cl = new ConsoleLogs(Logs.TypeMessege.info);
			cl.Write("wsdl загружена");


			Console.ReadKey();
		}
	}
}
