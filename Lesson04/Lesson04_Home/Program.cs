using System;

namespace Lesson04_Home
{
    class Program
    {
        //задаем палитру
        [Flags]
        enum  ColorsOf: byte
        {
            None=0,
            Black=1,
            Blue = 1<<1,
            Cyan = 1 <<2,
            Grey = 1 <<3,
            Green = 1 <<4,
            Magenta = 1 <<5,
            Red = 1 <<6,
            White = 1 <<7, 
            //Yellow = 1 <<8
        }

        static void Main(string[] args)
        {
            //ColorsOf MyFavouriteColors = ColorsOf.Black | ColorsOf.Green | ColorsOf.Red;
            //String str = "Black";
            //String str1 = "Blue";
            ColorsOf MyFavouriteColors1 =ColorsOf.None;
             //MyFavouriteColors1 = MyFavouriteColors1 | (ColorsOf)Enum.Parse(typeof(ColorsOf), str1);

            Console.WriteLine("Введите число соответствующее цвету:");
            string inputColor;
            for (int i=0; i<=3; i++)
            {
                inputColor = Console.ReadLine();
                MyFavouriteColors1 = MyFavouriteColors1 | (ColorsOf)Enum.Parse(typeof(ColorsOf), inputColor);

            }


               

            //ColorsOf MyNotFavouriteColors = ~MyFavouriteColors;
            //Console.WriteLine(MyFavouriteColors);
            Console.WriteLine(MyFavouriteColors1);

            //Console.WriteLine(MyNotFavouriteColors);

            Console.ReadKey();
        }
    }
}
