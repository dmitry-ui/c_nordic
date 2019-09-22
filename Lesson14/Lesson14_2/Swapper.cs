using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_2
{
    //public static class Swapper
    //{
    //    //универсальный метод
    //    public static void Swap<T>(ref T a, ref T b)
    //    {
    //        T temp = a;
    //        a = b;
    //        b = temp;
    //    }
    //}

    //универсальный класс
    public static class Swapper<T>
    {
              public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
