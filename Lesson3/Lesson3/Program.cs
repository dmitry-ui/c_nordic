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

            //////////////////массивы
            //string[] names = new string[5];
            //names[0] = "Дима";
            //names[1] = "Паша";
            //names[2] = "Саша";
            //names[3] = "Ната";
            //names[4] = "Люда";

            ////сразу с инициализацией
            //string[] names1 = {"Петр", "Алексей"};


            ////for (int i=0; i<names.Length;i++)
            ////{
            ////    Console.WriteLine(names[i]);
            ////}

            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.Write(names[i] + " ");
            //}

            //Console.WriteLine();
            //for (int i = 0; i < names1.Length; i++)
            //{
            //    Console.Write(names1[i] + " ");
            //}

            //определить два массива одинаковой 
            string[] trees = { "Ясень", "Липа", "Кедр" };
            int[] ages = { 32, 24, 43 };
            for (int i = 0; i < trees.Length; i++)
            {
                Console.WriteLine(trees[i] + " - возраст в годах: " + ages[i]);
            }




            //вывести таблицу Пифагора на экран
            //int[] First = { 1,2,3,4,5,6,7,8,9,10};
            //int[] Second = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //for (int i = 0; i < First.Length; i++)
            //    Console.Write(First[i] + "    ");
            //Console.WriteLine();
            //for (int i = 0; i < First.Length; i++)
            //    if (i==0)
            //        Console.Write(Second[i] + "    ");
            //    else
            //        Console.Write("{0}    ", First[i] * Second[i]);



            //прочитать из консоли 5 элементов типа int
            //вывести квадраты этих чисел
            Console.WriteLine("Введите первое натуральное число:");
            int val_1 = Console.ReadLine();












            Console.ReadKey();
        }
    }
}
