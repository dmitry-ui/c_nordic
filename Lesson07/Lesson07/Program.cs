using System;

namespace Lesson07
{
    class Program
    {
        static void Main(string[] args)
        {
            //только строки
//            string aa = "test";
//            string bb = "Test";
//            Console.WriteLine(aa == bb);
//            Console.WriteLine(aa.Equals(bb));
//            Console.WriteLine(aa.Equals(bb, StringComparison.InvariantCultureIgnoreCase));

//            // служебные символы    
//            Console.WriteLine("a\tb\nc");
//            Console.WriteLine("Console.WriteLine (\"a\\tb\\nc\")");

//            //включен numlock и зажата alt  и вводим код
//            string a = "test±";
//            string b = "t\u0045st\u00b1";   //тоже самое
//            Console.WriteLine(a);
//            Console.WriteLine(b);

//            //буквальные строки не учитывают esc-последовательности
//            //используется чтобы в путях не делать два слеша
//            Console.WriteLine(@"a\tb\nc");
//            //будет в трех строках из-за @
//            Console.WriteLine(@"Hello world!
//second line
//third line");

//            //можно так
//            Console.WriteLine("Hello world!\n" +"second line\n" + "third line\n");

//            //конкатенация 
//            string concat = " sd f  dfs dsf" + "sdfg sdf  d";
//            Console.WriteLine(concat);

//            int i = 1;
//            int j = 2;
//            Console.WriteLine(i + " plus " + j + " is " + (i + j));
//            Console.WriteLine("{0} plus {1} is {2}", i, j, i + j);


//            DateTime now = DateTime.Now;
//            DateTimeOffset nowOffset = DateTimeOffset.Now;  //с учетом часового пояса, можно сравнивать даты
//            Console.WriteLine(now + "\n" + nowOffset);

//            string result2 = string.Format("Now is {0:dd.MM.yyyy HH:mm}", now); //здесь 0:  это параметр для которого задаем формат после :
//            string result3 = string.Format("Now is {0:dd MMM.yyyy HH:mm}", now);
//            string result4 = string.Format("Now is {0:dd MMMM.yyyy HH:mm}", now);
//            string result5 = string.Format("Time is {0:HH:mm:ss}", now);
//            string result6 = string.Format("Time is {0:HH:mm:ss:fffffff}", now);
//            Console.WriteLine(result2);
//            Console.WriteLine(result3);   //месяц - 3 буквы
//            Console.WriteLine(result4);  //месяц полностью
//            Console.WriteLine(result5);
//            Console.WriteLine(result6);   //c 7 знаками после запятой


//            TimeSpan magicTime = DateTime.Now - DateTime.Parse("14.02.1982");
//            Console.WriteLine(magicTime.TotalDays);  //разница дат в днях

//            //интерполяция строк $
//            Console.WriteLine($"Now is {result2}");

			//поиск по строкам
			//string test = "Test string";
			//Console.WriteLine(test.Contains(" "));
			//Console.WriteLine(test.StartsWith("Te"));
			//Console.WriteLine(test.EndsWith("g"));

			//Console.WriteLine(test.IndexOf("s", 3));  // с какой позиции искать
			//Console.WriteLine(test.LastIndexOf("s"));

			//вывести все позиции буквы и в слове цивилизация
			string source = "цивилизации";
			string substring = "и";
			string answer=string.Empty;
			int FoundPosition=-1;
			do
			{
				FoundPosition = source.IndexOf(substring, FoundPosition + 1);
				if(FoundPosition>0)
				{
					answer += FoundPosition + " ";
				}
			}
			while (FoundPosition >= 0);
			
			if(answer==string.Empty)
			{
				answer = "-";
			}

			Console.WriteLine(answer);
		









			//Console.WriteLine("Hello World!");
			Console.ReadKey();
        }
    }
}
