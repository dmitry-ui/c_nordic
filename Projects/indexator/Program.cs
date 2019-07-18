using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexator
{
    //отказоустойчивый массив
    class FailStopArray
    {
        private int[] val;  //сам массив
        public int length; //длина массива
        public bool ErrVal; // ошибка чтения элемента массива

        //конструктор
        public FailStopArray(int size)
            {
            val = new int[size];
            length = size;
            }
        //ф-я проверки на корректность индекса
        private bool Okkey(int index)
        {
            if (index >= 0 & index < length)
            return true;
            return false; 
        }

        //индексатор т.е. как мы получаем и задаем элементы массива
        public int this[int size]
        {
            get
            {
                if(Okkey(size))
                {
                    ErrVal = false;
                    return val[size];
                }
                else
                {
                    ErrVal = true;
                    return 1000000;
                }

            }
            set
            {
                if (Okkey(size))
                {
                    ErrVal = false;
                    val[size] = value;
                }
                ErrVal = true;
                
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            FailStopArray fs = new FailStopArray(10);
            for (int i = 0; i < 15; i++)
                fs[i] = i;

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(fs[i]);
                if (fs.ErrVal) Console.WriteLine("Выход за границы");
            }
            Console.ReadKey();
        }
    }
}
