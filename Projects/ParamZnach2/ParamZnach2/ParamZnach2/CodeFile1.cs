using System;
class Perem
{
    public int i, j;
    public Perem(int a, int b)
    {
        i = a; j = b;
    }


    public void ChangeZnach(int a, int b)
    {
        a = a*100; b = b*100;
    }

    public void ChangeZnachByRef(ref int a, ref int b)
    {
        a = a * 100;
        b = b * 100;
    }

    public void ChangeREf(Perem val)
    {
        val.i = val.i * 2;
        val.j = val.j * 2;
    }
    public void Swap(ref int a, ref int b)
    {
        int c;
        c = a;
        a = b;
        b = c;
    }
    public void Show()
    {
        Console.WriteLine("i={0}; j={1}", i, j);
    }
}
class Decompose
{
    public int Decomp(double val, out double part)
    {
        int a = (int)val;
        part = val - a;
        return a;
    }
}
class Num
{
    /*
    Определить, имеется ли у числовых значений переменных х и v
    общий множитель. Если имеется, то возвратить наименьший и
    наибольший множители посредством параметров типа out. 
     */
     public bool CommonMnog(int a, int b, out int least, out int gratest)
    {
        least = 1;
        gratest = 1;
        int max = a < b ? a : b;
        bool first = true;
        //найдем  минимальный и максимальный общий множитель
        for(int i=2; i<max+1; i++)
        {
            if(a%i==0 && b%i==0)
               {
                    if(first)
                        {
                            least = i;
                            first = false;
                        }
                     gratest = i;
                       
                
               }

        }

        
        if (least > 1)
            return true;
        else return false;

    }

}
class REfSwap
{
    public int x;
    public int y;
    public REfSwap(int a, int b)
    {
        x = a; y = b;
    }
    public void Swap(ref REfSwap a, ref REfSwap b)
    {
        REfSwap temp;
        temp = a;
        a = b;
        b = temp;


    }
    public void Show()
    {
        Console.WriteLine("x={0}; y={1}", x, y);
    }

}
class Min
{
    public int Minimal(params int[] num)
    {
        int m;
        if (num.Length == 0) { Console.WriteLine("Параметры не переданы"); return 0; }
        else
        {
            //найдем минимальное значение из всех
            m = num[0];
            for(int i=1; i < num.Length; i++)
            {
                if(m < num[i])
                {
                    m = num[i];
                }
            }
            return m;
        }
    }
}
class Start
{
    static void Main()
    {
        Perem val1 = new Perem(10,20);
        int a = 35, b=49;
        //передача параметра типа значение по значению
        Console.WriteLine("Передача параметра типа значение (по значению):");
        Console.WriteLine("a={0}; b={1}", a, b);
        val1.ChangeZnach(a, b);
        Console.WriteLine("a={0}; b={1}", a, b);
        Console.WriteLine();
        
        //передача параметра типа класс по ссылке
        Console.WriteLine("Передача параметра типа класса (по ссылке):");
        val1.Show();
        val1.ChangeREf(val1);
        val1.Show();
        Console.WriteLine();

        //передача параметра типа значение по ссылке
        Console.WriteLine("Передача параметра типа значение (по ссылке):");
        Console.WriteLine("a={0}; b={1}", a, b);
        val1.ChangeZnachByRef(ref a, ref b);
        Console.WriteLine("a={0}; b={1}", a, b);
        Console.WriteLine();

        //используем передачу параметров по ссылке
        //для обмена значениями переменных
        Console.WriteLine("Обмен значениями:");
        Console.WriteLine("a={0}; b={1}", a, b);
        val1.Swap(ref a, ref b);
        Console.WriteLine("a={0}; b={1}", a, b);
        Console.WriteLine();

        //получим целую и дробную часть по отдельности
        double myVal = 12.123;
        Console.WriteLine("myVal={0}", myVal);
        Decompose d = new Decompose();
        double doublePart;
        int intPart = d.Decomp(myVal, out doublePart);
        Console.WriteLine("intPart={0}; doublePart={1}", intPart, doublePart);
        Console.WriteLine();

        //поиск минимального и максимального общего множителя
        int m = 35, n = 49;
        int least, gratest;
        Num Temp = new Num();
        bool status = Temp.CommonMnog(m, n, out least, out gratest);
        Console.WriteLine("Поиск общих множителей:");
        Console.WriteLine("m={0}; n={1}", m, n);
        Console.WriteLine("least={0}; gratest={1}", least, gratest);
        Console.WriteLine();

        //передача объектов типа класса по ссылке
        Console.WriteLine("Смена объектов под ссылками:");
        REfSwap p = new REfSwap(17, 43);
        REfSwap q = new REfSwap(235, 411);
        p.Show();
        q.Show();
        p.Swap(ref p, ref q);
        p.Show();
        q.Show();
        Console.WriteLine();

        //переменное количество параметров в методе
        Console.WriteLine("Переменное количество параметров в методе:");
        Min qw= new Min();
        int[] array = new int[27];
        for(int i=0; i < array.Length; i++)
        {
            array[i] = i;
        }
        int minVal=qw.Minimal(array);
        Console.WriteLine("Минимальное значение: {0}", minVal);
    }
}