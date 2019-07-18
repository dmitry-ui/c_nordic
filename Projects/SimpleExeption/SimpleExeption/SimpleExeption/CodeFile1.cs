using System;
//class Start
//{
//    static void Main()
//    {
//        int[] array = new int[5];
//        //создадим исключительную ситуацию
//        try
//        {

//            for (int i = 0; i < array.Length; i++)
//            {
//                array[i] = i;
//                Console.WriteLine("array[{0}] = {1}", i, array[i]);
//            }
//            Console.WriteLine("Присваивание завершено");

//        }
//        catch (IndexOutOfRangeException)
//        {
//            Console.WriteLine("Исключение.\nПревышение границ массива");
//        }

//        for (int i = 0; i<array.Length; i++)
//        {
//            Console.WriteLine("array[{0}] = {1}", i, array[i]);
//        }



//    }
//}

///////////

//class MyArray
//{
//    public static void SetArray()
//    {
//        int[] Arr = new int[10];
//        for (int i =0; i<10; i++)
//        {
//            Arr[i] = i;
//            Console.WriteLine("Arr[{0}]={1}",i,Arr[i]);
//        }
//    } 
//}

//class Start
//{
//   static void Main()
//    {
//        int a = 15;
//        try
//        {
//            MyArray.SetArray();

//            a = a / (a - 15);
//        }
//        catch (IndexOutOfRangeException)
//        {
//            Console.WriteLine("Исключение. Превышение границ массива.");
//        }
//        catch (DivideByZeroException)
//        {
//            Console.WriteLine("Исключение. Деление на ноль.");
//        }
//        Console.WriteLine("a={0}",a);

//    }
//}

///////////////////////////////////////////////


//    class Start
//{
//    static void Main()
//    {
//        int[] a = new int[] { 2, 3, 5, 7, 9, 10 };
//        int[] b = new int[] { 2, 0, 5, 7, 0 };

//            for (int i = 0; i < a.Length; i++)
//            {
//                try
//                {
//                    Console.WriteLine("a[{0}] / b[{0}] = {1}", i, a[i] / b[i]);
//                }
//                 catch (DivideByZeroException)
//                {
//                    Console.WriteLine("Исключение. Деление на ноль.");
//                }
//                catch(IndexOutOfRangeException)
//                {
//                Console.WriteLine("Исключение. Превышение границ массива.");
//            }
//            }


//        Console.WriteLine("Деление массивов выполнено.");

//    }
//}
//DivideByZeroException

/// <summary>
/// вложенные блоки try
/// </summary>
//class Start
//{
//    static void Main()
//    {
//        int[] a = new int[] { 2, 3, 5, 7, 9, 10 };
//        int[] b = new int[] { 2, 0, 5, 7, 0 };
//        try
//        {
//            for (int i = 0; i < a.Length; i++)
//            {
//                try
//                {
//                    Console.WriteLine("a[{0}] / b[{0}] = {1}", i, a[i] / b[i]);
//                }
//                catch (DivideByZeroException)
//                {
//                    Console.WriteLine("Исключение. Деление на ноль.");
//                }

//            }

//        }
//        catch (IndexOutOfRangeException)
//        {
//            Console.WriteLine("Исключение. Превышение границ массива.");
//        }
    
       

//        Console.WriteLine("Деление массивов выполнено.");

//    }
//}


//

    //использование переменной типа исключение
//    class MyException
//{
//    static int[] array = new int[5];
//    public static void SetException()
//    {
//        for (int i = 0; i<10; i++)
//        {
//            array[i] = i;
//        }
//    }

//}

//class Start
//{
//    static void Main()
//    {
//        try
//        {
//            MyException.SetException();
//        }
//        catch (IndexOutOfRangeException val)
//        {
//            //Console.WriteLine(val);
//            Console.WriteLine(val.Message);
//            //Console.WriteLine(val.StackTrace);
//            Console.WriteLine(val.TargetSite);
//        }

//    }
//}


    //нулевая ссылка
    class MyClass
{
    int a;
    public void Set(int x) { a = x; }
    public int Add(MyClass Ab) { return (a + Ab.a);}
}

class Start
{
    static void Main()
    {
        MyClass a = new MyClass();
        MyClass b = new MyClass();
        int val;
        a.Set(5);
        b=null;      //присваиваем нулевую ссылку
        val = a.Add(b);
        Console.WriteLine("val={0}", val);

    }
}
