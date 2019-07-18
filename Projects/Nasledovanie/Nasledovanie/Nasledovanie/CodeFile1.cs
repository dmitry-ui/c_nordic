using System;
class TwoDimFigure
{
    private int a;
    private int b;
    public int PropA
    {
            get { return a; }
            set { a = value < 0 ? -value : value;
 }
        
    }
    public int PropB
    {
        get { return b; }
        set { b = value < 0 ?-value: value; }
    }
    public int GetA()
    {
        return a;
    }
    public int GetB()
    {
        return b;
    }
    public TwoDimFigure()
    {
        a = 10;
        b = 5;
    }
    public void Show()
    {
        Console.WriteLine("Длина фигуры: {0}, ширина фигуры: {1}.",PropA,PropB);
    }
}

class Triangle: TwoDimFigure
{
    public void Square()
    {
        Console.WriteLine("Площадь треугольника: {0}.", PropA*PropB/2);
    }
}

class Start
{
    static void Main()
    {
        TwoDimFigure fig = new TwoDimFigure();
        fig.Show();

        Triangle tri = new Triangle();
        tri.Show();
        tri.Square();
    }

}