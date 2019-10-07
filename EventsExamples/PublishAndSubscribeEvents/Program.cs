using System;

namespace PublishAndSubscribeEvents
{
	class Program
	{
		static void Main(string[] args)
		{
			Publisher pub = new Publisher();
			Subscriber sub1 = new Subscriber("sub1", pub);
			Subscriber sub2 = new Subscriber("sub2", pub);

			// Call the method that raises the event.
			pub.DoSomething();

			// Keep the console window open
			Console.WriteLine("Press Enter to close this window.");
			Console.ReadLine();
		}
	}
}
