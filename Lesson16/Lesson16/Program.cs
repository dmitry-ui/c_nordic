using System;
using Geometry;
using Newtonsoft.Json;

namespace Lesson16
{
	class Program
	{
		//опишем делегат
		//delegate int DoCalculation(int a, int b);
		static void Main(string[] args)
		{
			//создадим делегат
			//DoCalculation doCalc;
			//doCalc = SimpleCalculator.Sum; //связали с методом

			//Console.WriteLine(SimpleCalculator.Sum(10, 5));

			////вызовем делегат
			//Console.WriteLine(doCalc(10, 5));

			//Console.WriteLine(SimpleCalculator.Multiply(10, 5));

			////через делегат
			//doCalc = SimpleCalculator.Multiply;
			//Console.WriteLine(doCalc(10, 5));

			//DoCalculation doCalc2 = new DoCalculation(SimpleCalculator.Sum); // по другому

			//делаем комбаин из двух делегатов
			//DoCalculation doCalc1 = SimpleCalculator.Sum;
			//DoCalculation doCalc2 = SimpleCalculator.Multiply;
			////doCalc1 = (DoCalculation)Delegate.Combine(doCalc1, doCalc2);

			//DoCalculation doCalc3 = SimpleCalculator.Devide;
			//doCalc3 += doCalc1;
			//doCalc3 += doCalc2;

			////doCalc3 -= doCalc1;
			//doCalc3 = (DoCalculation)Delegate.Remove(doCalc3, doCalc1);  //вычли. теперь сумма не участвует в последовательном вызове
			////Delegate.Combine(doCalc1, doCalc2);
			//Console.WriteLine(doCalc3(10, 5));  //последний рез-т перезатирает предыдущий

			//типы делегатов:
			//Action   -   не возвращает значение
			//Function  -  возвращает значение

			//самостоятельная работа
			Circle circle = new Circle(1.5);
			Console.WriteLine(circle.Calculate(CalcCircle.Perimetr));
			Console.WriteLine(circle.Calculate(CalcCircle.Square));
			//или через лямбда-выражения
			//при этом в классе методы площадь и периметр не нужны, как и сам класс CalcCircle
			Console.WriteLine(circle.Calculate(x => 2 * Math.PI * x));
			Console.WriteLine(circle.Calculate(x=> Math.PI * x * x));

			Rectangle rectangle = new Rectangle(4, 2);
			Console.WriteLine("Площадь: " + rectangle.Calculate((x, y)=> x*y));
			Console.WriteLine("Периметр: " +rectangle.Calculate((x, y) => (x + y)*2));

			//переносим классы в библиотеку классов и добавляем ее в зависимости в проекте справа
			//добавляем зависимость Ньютона.json

			var jsonData = JsonConvert.SerializeObject(
				new
				{//создаем любой объект
					Name  = "Dima",
					Age = 21,
					Sex = 'M',
					IsActive = true
				});
			Console.WriteLine(jsonData);
			Console.ReadKey();
		}
	}
}
