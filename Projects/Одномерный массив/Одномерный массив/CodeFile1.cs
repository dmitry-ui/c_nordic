using System;
class Empty3
{
    static void Main()
    {
        /* int i;
         int sum = 0;
         // получить сумму чисел от 1 до 5
         for (i = 1; i <= 5; sum += i++) ;
         Console.WriteLine("Сумма равна " + sum);
         */
        /*  string str;
          Console.WriteLine("Введите строку");
          str = Console.ReadLine();
          Console.WriteLine("Вы ввели строку \"" + str+"\"");
          */

        // Declare a single-dimensional array 
        string Ent;
        int[] array1 = new int[5];
        Start:
        Console.WriteLine("Введите  элементы массива");
        for (int i = 0 ; i < 5 ; i++ )
        {
            Console.WriteLine("Введите  элемент " + i +":");
            //Получение строки
            string userString = Console.ReadLine();

            //Преобразование строки в число (в тип int)
            array1[i] = Convert.ToInt32(userString);
        }

        //найдем сумму элементов
        int sum = 0;
        for (int i = 0; i < 5; i++)
        {
            sum = sum + array1[i];
        }
        Console.WriteLine("Сумма всех элементов sum = " + sum);

        //найдем сумму всех четных элементов
        int sumchet = 0;
        for (int i = 0; i < 5; i++)
        {
            if (array1[i] % 2 == 0)
                sumchet = sumchet + array1[i];
        }
        Console.WriteLine("Сумма всех четных элементов sum = " + sumchet);
        Console.WriteLine("Повторить задание (y/n)?");
        Ent = Console.ReadLine();
        if (Ent == "y" || Ent == "Y")
          {
                 goto Start;
          }
        //   Environment.Exit(0);
        //
        //Console.WriteLine("Введите символ:");
        //char k = Console.ReadKey().KeyChar;


    }
}
