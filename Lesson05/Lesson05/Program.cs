using System;

namespace Lesson05
{
    class Program
    {
        enum Color
        {
            Red, Green, Blue, Yellow
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Нажмите любую клавишу");
            //char c = Console.ReadKey().KeyChar;
            //if(char.IsLetterOrDigit(c))
            //{
            //    Console.WriteLine("Нажата буква или цифра");
            //}
            //else
            //{
            //    Console.WriteLine("Нажата странная клавиша!!!!!");
            //}
            //запросить число от 1 до 100
            //вывести фразу   XXX год,  ХХХ года, ХХХ лет
            Console.WriteLine("Введите число от 1 до 100:");
            int val=0;
            string str = Console.ReadLine();
            try
            {
                val = int.Parse(str);
            }
            catch (FormatException e)
            {
                
                Console.WriteLine("Ошибка парсинга\n '{2} {1}'\n  Мы используем значение по умолчанию {0}", val, e.Message, e.GetType());
            }
            catch (OverflowException e)
            {

                Console.WriteLine("Ошибка переполнения\n '{2} {1}'\n  Мы используем значение по умолчанию {0}", val, e.Message, e.GetType());
            }
            finally                                                 //здесь мы будем в любом случае
            {
                val++;
                Console.WriteLine("Мы в finally val={0}", val);
                   //выполнится в любом случае 
            }


            if (val>100 ||val<1)
                throw new ArgumentOutOfRangeException("Значение должнобыть меньше 100!!");

            if (val == 1 || val == 11 || val == 21 || val == 31 || val == 41 || val == 51 || val == 61 || val == 71 || val == 81 || val == 91)      //
            {
                Console.WriteLine("{0} год.", val);
            }

            else if (val == 2 || val == 3 || val == 4 || (val >= 22 && val <= 24) || (val >= 32 && val <= 34)
                    || (val >= 42 && val <= 44) || (val >= 52 && val <= 54) || (val >= 62 && val <= 64) || (val >= 72 && val <= 74)
                    || (val >= 82 && val <= 84) || (val >= 92 && val <= 94))
            {
                Console.WriteLine("{0} года.", val);
            }

            else if ((val >= 5 && val <= 20) || (val >= 25 && val <= 30) || (val >= 35 && val <= 40) || (val >= 45 && val <= 50)
                    || (val >= 55 && val <= 60) || (val >= 65 && val <= 70) || (val >= 75 && val <= 80) || (val >= 85 && val <= 90)
                    || (val >= 95 && val <= 100))
            {
                Console.WriteLine("{0} лет.", val);
            }


            //тернарный оператор
            //int val3 = val < 50 ? val : -val;  //

            //запросить число от 1 до 100. В зав-ти от того больше 50 оно или нет
            //Console.WriteLine("Введите число от 1 до 100:");
            //string my_string = Console.ReadLine();
            //int value = int.Parse(my_string);
            //string res;
            ////res = value < 50 ? "Число меньше 50" : "Число больше или равно 50";
            ////Console.WriteLine(res);

            ////можно сразу в строку
            //Console.WriteLine(res = value < 50 ? "Число меньше 50" : "Число больше или равно 50");


            //switch
            //Color c = (Color)(new Random()).Next(0, 5); // генерим случайный цвет 0 - первый цвет, 4 - не входит в цвет
            //switch(c)
            //{
            //    case Color.Red:
            //        Console.WriteLine("Color is red");
            //        break;
            //    case Color.Green:
            //        Console.WriteLine("Color is green");
            //        break;
            //    case Color.Blue:
            //        Console.WriteLine("Color is Blue");
            //        break;
            //}
            ////можно объединять ветки
            //switch (c)
            //{
            //    case Color.Red:
            //    case Color.Yellow:
            //        Console.WriteLine("Color is red or yellow");
            //        break;
            //    case Color.Green:
            //        Console.WriteLine("Color is green");
            //        break;
            //    case Color.Blue:
            //        Console.WriteLine("Color is Blue");
            //        break;
            //}

            //исключения
            //напр деление на ноль
            //запросить число от 1 до 100. В зав-ти от того больше 50 оно или нет
            //Console.WriteLine("Введите число от 1 до 100:");
            //string my_string = Console.ReadLine();
            //int value = int.Parse(my_string);
            //if(value>=100)
            //{
            //    throw new Exception("Значение должнобыть меньше 100!!");
            //}
            //Console.WriteLine("Вы ввели корректное число.");




            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}
