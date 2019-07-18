using System;
class MyParam
{
    public void Show(string str, params int[] num)
    {
        Console.Write(str + " ");
        for(int i=0; i < num.Length; i++)
        {
            Console.Write(num[i] + ", ");
        }
        Console.WriteLine();
    }
}
class Rectangle
{
    private int a;
    private int b;
    public Rectangle(int x, int y)
        {
            a = x;
            b = y;
        }
    public void Show()
    {
        Console.WriteLine("a={0}, b={1}", a, b);
    }
    public int Area()
    {
        return a * b;
    }
    public void ShowArea()
    {
        Console.WriteLine("Площадь: {0}", Area());
    }
    public Rectangle RectTo2()
    {
        return new Rectangle(a * 2, b * 2);
    }
}




class Start
{
    static void Main()
    {
        int[] array = new int[5] { 1, 2, 3, 4, 5 }; 
        MyParam sa = new MyParam();
        //в списке параметров и обычные параметр и параметры переменной длины
        //параметры переменной длины должны быть в конце и дб только один параметр переменной длины 
        sa.Show("Некая строка:", array);
        sa.Show("Другая строка", 23, 34, 454, 56);
        sa.Show("Другая строка", 23, 34, 454, 56, 67, 87, 345);

        Console.WriteLine();
        Rectangle r1 = new Rectangle(1, 2);
        Rectangle r2 = r1.RectTo2();
        r1.Show();
        r1.ShowArea();
        r2.Show();
        r2.ShowArea();


    }
}