using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            //типы переменных - значения и ссылки
            //разница  смысл - стек и куча
            //тип Object

            //object name = "Андрей";
            //object age = 36;
            //object height = 12.2;

            //ошибка:
            //int length1 = name.Length;

            //int length2 = ((string)name).Length;
            //Console.WriteLine(length2);
            //Console.WriteLine(((string)age).Length);//сам себе патрон в ногу. компилируется, но не работает

            //int length3 = ((string)height).Length;
            //Console.WriteLine(length3);

            //string input = Console.ReadLine();
            //Console.WriteLine("\"" + input + "\"");

            //Console.WriteLine("\"" + Console.ReadLine() + "\"");  //плохо, но работает

            //Console.WriteLine("\"" + Console.ReadLine() + Console.ReadLine() + "\"");  //плохо, но работает

            //Console.WriteLine(2019 - (int)age);
            //age = (int)age - 1;

            ////аналогично но приведение типов на лету. ОПАСНО
            //dynamic anotherName = "Alex";
            //int length = anotherName.Length;
            //Console.WriteLine(length);

            ////если var то реальный тип будет определяться на этапе компиляции
            //var qw = 15;
            //var str = "sdfdfr";
            ////аналогично
            //int qw1 = 15;
            //string str1 = "sdfdfr";

            //значения типов по умолч
            //Console.WriteLine("{0}", default(float));
            //Console.WriteLine("{0}", default(double));
            //Console.WriteLine("{0}", default(decimal));
            //object ob  =default(object);  //содержит null
            //dynamic dn =default(dynamic);
            //string st = default(string);

            //можно хранить Null если поставить ?
            //int? i;
            ////i = null;
            //i = 2;
            //Console.WriteLine(i.HasValue); //проверить есть ли значение в переменной
            //Console.WriteLine(i.Value);   //будет работать только если есть значение у переменной

            //массивы






            Console.ReadKey();
        }
    }
}
