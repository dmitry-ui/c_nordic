
//пример 2 в степени от 1 до 16
using System;
//индексаторы без массива
class Indexators
{
    private int My_pwr(int k)
    {
        int res = 1;
        for (int i = 1; i <= k; i++)
            res = res * 2;
        return res;
    }
    public int this [int index]
    {
        get
        {
            if (index > 0 && index <= 16)
            {
                
                return My_pwr(index);
            }
            else return -1;
        }
    }
}

//свойство - для огрпничения операций над переменной
class Properties
{
    private int i;
    public Properties() { i = 0; }
    public void Show() { Console.WriteLine("{0}", i); }
    public int MyProp
    {
        get { return i; }
        set
        {
            if(value > 0 ) { i = value; }
        }
    }
}
class Start
{
    static void Main()
    {
        int i = 16;
        Indexators a = new Indexators();
        //работаем как с массивом
        Console.WriteLine("2 в степени {0}  равно {1}", i, a[16]);

        //свойсто
        Properties temp = new Properties();
        temp.MyProp=100;
        temp.Show();
        temp.MyProp = 50;
        temp.Show();
        temp.MyProp *= 2;
        temp.Show();
        //а так не присвоится из-за ограничения в свойстве
        temp.MyProp = - 50;
        temp.Show();


    }
}