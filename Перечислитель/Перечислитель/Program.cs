using System;
using System.Collections;

namespace Перечислитель
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] my_bytes = new byte[10];

                        
            //инициализация
            for (byte i=0; i< my_bytes.Length; i++)
            {
                my_bytes[i] = i;
                //Console.Write($"{my_bytes[i]}, ");
            }

            //перебор
            foreach(byte b in my_bytes)
            {
                Console.Write($"{b}, ");
            }
            Console.WriteLine();

            //перебор по другому, с помощью перечислителя
            IEnumerator enumerator = my_bytes.GetEnumerator();
            while (enumerator.MoveNext())
                Console.Write(enumerator.Current + ", ");
            Console.WriteLine();
            //аналогично со своим классом
            //не работает если не реализован перечислитель
            MyBytes MB = new MyBytes();
            foreach (byte b in MB)
            {
                Console.Write($"{b}, ");
            }
            Console.WriteLine();
            //так тоже не работает
            IEnumerator enum2 = MB.GetEnumerator();
            while (enum2.MoveNext())
                Console.Write(enum2.Current + ", ");
            //после реализации интерфейсов все работает


            Console.ReadKey();
        }
    }

    class MyBytes : IEnumerator, IEnumerable
    {
        byte[] my_bytes = new byte[10] {2,4,6,8,10,12,14,16,18,20};
        sbyte index = -1;

        public object Current
        {
            get { return my_bytes[index]; }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (index == (my_bytes.Length - 1))
            {
                index = -1;
                return false;
            }
            index += 1;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
