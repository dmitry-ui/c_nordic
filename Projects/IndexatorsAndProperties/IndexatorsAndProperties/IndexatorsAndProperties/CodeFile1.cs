using System;
class MyArray
{
    private int[] i;
    private int len;
    private bool MyArrayError;
    public MyArray(int a)
    {
        i = new int[a];
        len = a;
    }
    public bool Okey(int index)
    {
        if (index >= 0 && index < len)
        {

            return true;
        }

        else return false;
    }
    //свойство только для чтения
    public bool ArrayError
    {
        get
        {
            return MyArrayError;
        }
    }
    //свойство только для чтения
    public int Length
    {
        get
        {
            return len;
        }
    } 

    //не допустим превышения границ массива
    public int this[int index]
    {
        get
        {
            if (Okey(index)) { MyArrayError = false; return i[index]; }
            else { MyArrayError = true; return -100; }
        }
        set
        {
            if (Okey(index))
            {
                MyArrayError = false;
                i[index] = value;
            }
            else MyArrayError = true;
        }
    }
}

class Start
{
   static void Main()
    {
        int x;
        MyArray a = new MyArray(10);
        //присвоим значения не потопляемому массиву
        for (int i = 0; i<a.Length+1; i++)
        {
            a[i] = i;
        }

        //прочитаем данные из непотопляемом массиве
        for (int i = 0; i < a.Length+1; i++)
        {
            x = a[i];
            if (!a.ArrayError) Console.Write(x);
        }

    } 
}