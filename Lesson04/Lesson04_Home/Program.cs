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
            Cyan = 1<<2,
            Grey = 1<<3,
            Green = 1<<4,
            Magenta = 1<<5,
            Red = 1<<6,
            White = 1<<7
           // Yellow = 9
        }

        static void Main(string[] args)
        {
            ColorsOf FavouriteColors =ColorsOf.None;
            //ColorsOf AllColors;
            //AllColors = ColorsOf.Black | ColorsOf.Blue | ColorsOf.Cyan | ColorsOf.Green | ColorsOf.Grey | ColorsOf.Magenta | ColorsOf.Red | ColorsOf.White;
            //ColorsOf tempColorsOf= ColorsOf.Black;
            //for (tempColorsOf = ColorsOf.Black; tempColorsOf <= ColorsOf.White; tempColorsOf++)
            //    Console.WriteLine("{0} - {1}", tempColorsOf, (byte)tempColorsOf);
            
            //вывод всей коллекции
            Console.WriteLine("\nВся коллекция:");
            foreach (string i in Enum.GetNames(typeof(ColorsOf)))
                Console.WriteLine(i);

            Console.WriteLine("\nИх коды(соответственно):");
            foreach (byte i in Enum.GetValues(typeof(ColorsOf)))
                Console.WriteLine(i);
            

            //выбираем 4 любимых цвета
            //надо бы TryParse
            Console.WriteLine("\nВведите 4 любимых цвета(можно их коды):\n");
            string inputColor;
            for (int i = 0; i <= 3; i++)
            {
                inputColor = Console.ReadLine();
                FavouriteColors = FavouriteColors | (ColorsOf)Enum.Parse(typeof(ColorsOf), inputColor);
            }

            //вывод любимых цветов
            Console.WriteLine("\nЛюбимые цвета:");
            Console.WriteLine(FavouriteColors);

            //получение и вывод остальных цветов
            ColorsOf NotFavouriteColors = ~FavouriteColors;
            Console.WriteLine("\nОстальные цвета:");
            Console.WriteLine(NotFavouriteColors);
            
            Console.ReadKey();
        }
    }
}
