using System;
class Factory
{
    public int i;
    public int j;
    public Factory(int a, int b)
    {
        i = a; j = b;
    }
    public void Show()
    {
        Console.WriteLine("i={0}, j={1}", i, j);
    }
    public static Factory CreateFactory(int a, int b)  //статический метод лучше
    {
        Factory Temp = new Factory(a, b);
        return Temp;
    }
}
class Mnogitels
{
    public int [] GetMnogitels(int val, out int total)
    {
        int[] mnog = new int[100];
        int j = 0;
        for(int i=1; i < val/2 +1; i++)
        {
            if(val%i==0)
            {
                mnog[j] = i;
                j++;
            }
        }
        total = j;
        return mnog;
    }
}

class Start
{
    static void Main()
    {
        //  Factory ob = new Factory(1,2);  //так нужно если  нестатический метод  Factory
        for (int i=0, j=10; i < 10; i++, j--)
        {
            //Factory Another = ob.CreateFactory(i, j);  //так нужно если  нестатический метод  Factory
            Factory.CreateFactory(i, j).Show();
            //Another.Show();

        }
        
        //получим множители числа
        Console.WriteLine();
        int a = 100;
        int total;
        Mnogitels mn = new Mnogitels();
        int[] res;
        res = mn.GetMnogitels(a, out total);
        //вывод множителей
        Console.WriteLine("Множители числа {0}:",a);
        for (int i=0; i<total; i++)
        {
            Console.Write(res[i] + ", ");
        }

    }
}
