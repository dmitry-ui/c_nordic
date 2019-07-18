using System;
class Array
{
 static void Main()
    {
        int[] point = new int[5];
        int[] copy_point = point;  // по сути тот же объект
        for(int i=0; i< point.Length; ++i)
        {
            point[i] = i;
        }

//вывод
        for (int i = 0; i < point.Length; ++i)
        {
            Console.Write(point[i] + ", ");
        }

        for (int i = 0; i < copy_point.Length; ++i)
        {
            copy_point[i] = 2*i;
        }

        //вывод
        Console.WriteLine();
        for (int i = 0; i < point.Length; ++i)
        {
            Console.Write(point[i] + ", ");
        }

    }
}