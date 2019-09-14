using System;
using System.Collections;

namespace weeks
{
    class Program
    {
        static void Main(string[] args)
        {
            Week week = new Week();

            //работает благодря реализации IEnumerable
            foreach (var day in week)
            {
                Console.WriteLine(day);
            }

            Console.ReadKey();
        }
    }

    class Week : IEnumerable

    {
        public string[] wk = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

        //нужно для возможности перебора в foreach
        public IEnumerator GetEnumerator()
        {
            return wk.GetEnumerator();
        }
    }
}
