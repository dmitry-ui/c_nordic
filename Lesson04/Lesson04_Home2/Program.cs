using System;

namespace Lesson04_Home2
{
    class Program
    {
        //типы контейнеров, их емкость
        [Flags]
        enum Containers
        {
            big = 20,
            middle = 5,
            small = 1
        }

        //флаги используемых контейнеров
        [Flags]
        enum FlagsContainers
        {
            EnabledBig=0b1,
            EnaledMiddle = 0b10,
            EnabledSmall =0b100
        }

        static void Main(string[] args)
        {
            int bigQuantity=0;       //количество больших контейнеров
            int bigBalance=0;        //остаток литров для дальнейшей расфасовки
            int middleQuantity = 0;  //количество средних контейнеров
            int middleBalance = 0;   //остаток литров для дальнейшей расфасовки 
            int smallQuantity = 0;    //количество малых контейнеров
            int smallBalance = 0;    //остаток литров для дальнейшей расфасовки 
            int Total =0;             //всего литров для расфасовки
            FlagsContainers FC = 0b000;  //флаги, показывают какие контейнеры понадобятся

            Console.Write("\nВведите количество литров для расфасовки: ");
            string InputQuantity = Console.ReadLine();
            Total = int.Parse(InputQuantity);

            //считаем сколько нужно больших контейнеров
            //и сколько останется литров для дальней расфасовки
            bigQuantity = Total / (int)Containers.big;
            bigBalance = Total % (int)Containers.big;
            //если большие контейнеры нужны, выставляем флаг
            if (bigQuantity != 0)
                FC = FC | FlagsContainers.EnabledBig;

            //считаем сколько нужно средних контейнеров
            //и сколько останется литров для дальней расфасовки
            middleQuantity = bigBalance / (int)Containers.middle;
            middleBalance = bigBalance % (int)Containers.middle;
            //если средние контейнеры нужны, выставляем флаг
            if (middleQuantity != 0)
                FC = FC | FlagsContainers.EnaledMiddle;

            //считаем сколько нужно малых контейнеров
            //и сколько останется литров для дальней расфасовки
            smallQuantity = middleBalance / (int)Containers.small;
            smallBalance = middleBalance % (int)Containers.small;
            //если малые контейнеры нужны, выставляем флаг
            if (smallQuantity != 0)
                FC = FC | FlagsContainers.EnabledSmall;

            //вывод количества необходимых контейнеров в зависимости от выставленных флагов
            Console.WriteLine("\nДля фасовки понадобилось:\n");
            
            //если понадобились большие контейнеры...
            if ((FC & FlagsContainers.EnabledBig)== FlagsContainers.EnabledBig)
            {
                Console.WriteLine("{0} контейнеров по {1} литров", bigQuantity, (int)Containers.big);
            }

            //если понадобились средние контейнеры...
            if ((FC & FlagsContainers.EnaledMiddle) == FlagsContainers.EnaledMiddle)
            {
                Console.WriteLine("{0} контейнеров по {1} литров", middleQuantity, (int)Containers.middle);
            }

            //если понадобились малые контейнеры...
            if ((FC & FlagsContainers.EnabledSmall) == FlagsContainers.EnabledSmall)
            {
                Console.WriteLine("{0} контейнеров по {1} литров", smallQuantity, (int)Containers.small);
            }

            Console.WriteLine("\n\nДля выхода из программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
