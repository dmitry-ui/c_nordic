 using System;

namespace Lesson3_Home
{
    class Program
    {
        static void Main(string[] args)
        {

           //1 способ
            Console.WriteLine();
            Console.WriteLine("1 способ");
            int[] first = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] second = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            for (int i = 0; i < second.Length; i++)
            {
                for (int j = 0; j < first.Length; j++)
                {
                    Console.Write("{0} \t", second[i] * first[j]);
                }
                Console.WriteLine();
            }


            //2 способ
            Console.WriteLine();
            Console.WriteLine("2 способ");
            int mFirst = 2;  //первый множитель начало
            int mStep = 2;  //приращение первого множителя
            int mEnd = 20;  //первый множитель конец

            int nFirst = 2;   //второй множитель начало
            int nStep = 1;  //приращение второго множителя
            int nEnd = 18;    //второй множитель конец

            //вывод первого множителя
            Console.Write("".PadLeft(6, ' '));
            for (int i = mFirst; i <= mEnd; i+=mStep)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(Convert.ToString(i, 10).PadLeft(6, ' '));
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();

            //вывод второго множителя и произведений на первый множитель по строке
            for (int m = nFirst; m <= nEnd; m+=nStep)
            {
                //вывод второго множителя
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(Convert.ToString(m, 10).PadLeft(6, ' '));
                Console.ForegroundColor = ConsoleColor.White;
                //вывод произведений
                for (int n = mFirst; n <= mEnd; n+=mStep)
                {
                    //  Console.Write("{0} \t", second[i] * first[j]);
                    Console.Write(Convert.ToString(m * n, 10).PadLeft(6, ' '));
                }
                Console.WriteLine();  //переход на новую строку
            }
            Console.WriteLine();

            Console.ReadKey(); 
            
            
           




                    //прочитать из консоли 5 элементов типа int
                    //вывести квадраты этих чисел
            //        Console.WriteLine("Еще ДЗ.");
            //int[] res = new int[5];  
            //Console.WriteLine("Введите пять целых чисел:");
            //for(int i=0; i<5; i++)
            //{
            //    Console.WriteLine("Введите {0} число:", i+1);
            //    res[i] = Convert.ToInt32(Console.ReadLine());
            //}
            ////вывод квадратов введеных чисел
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write("{0}*{0}={1}   \t", res[i], res[i] * res[i]);
            //}
            //Console.WriteLine();
            Console.ReadKey();

        }
    }
}
