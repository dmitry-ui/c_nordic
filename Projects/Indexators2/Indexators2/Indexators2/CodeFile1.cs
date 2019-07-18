using System;
class Indexators
{
    private int[] Array;
    public int Length;
    public bool ErrorAray;
    public Indexators(int i)
    {
        Array = new int[i];
        Length = i;
    }
    private bool Okey(int index)
    {
        if ((index > -1) && (index < Array.Length))
            return true;
        else return false;

    }
    //индексатор
    public int this [int index]
    {
        //чтение 
        get
        {
            if (Okey(index))
            {
                ErrorAray = false;
                return Array[index];
            }
            else
            {
                ErrorAray = true;
                return 0;
            }
        }
        //присваивание
        set
        {
            if(Okey(index))
            {
                ErrorAray = false;
                Array[index] = value;
            }
            else
            {
                ErrorAray = true;
            }
        }
    }
}


class Start
{
    static void Main()
    {
        Indexators a = new Indexators(10);
        //выйдем за границы массива при присваивании
        for (int i = 0; i < a.Length + 5; i++)
        {
            if (a.ErrorAray) Console.WriteLine("Превышение границ.");
            a[i] = i;
        }
        //выйдем за границы массива при считывании
        for (int i = 0; i < a.Length + 5; i++)
        {
            Console.Write("{0}, ", a[i]);
            if (a.ErrorAray) Console.WriteLine("Превышение границ.");
        }

    }
}