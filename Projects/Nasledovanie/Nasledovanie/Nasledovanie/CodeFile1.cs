using System;
class TwoDimFigure
{
    //переменные класса
    private int a;
    private int b;
    //доступ к закрытым членам класса через свойства
    //свойства на переменные класса
    public int PropA
    {
            get { return a;}
            set { a = value < 0 ? -value : value;}
        
    }
    public int PropB
    {
        get { return b; }
        set { b = value < 0 ?-value: value; }
    }
    //функции 
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
    //gtht
    public string typeOffTriangle;

    //функции
    public void ShowType()
    {
        Console.WriteLine("Тип треугольника: {0}", this.typeOffTriangle);
    }
    public void Square()
    {
        Console.WriteLine("Площадь треугольника: {0}.", PropA*PropB/2);
    }
}
class Rectangle:TwoDimFigure
{
    public void Area()
    {
        Console.WriteLine("Площадь прямоугольника: {0}", PropA * PropB);
        //Console.WriteLine("Площадь прямоугольника: {0}", a * b);
    }

}
class Start
{
    static void Main()
    {
        TwoDimFigure fig = new TwoDimFigure();
        fig.Show();
        
        //треугольник
        Triangle tri = new Triangle();
        tri.typeOffTriangle = "Тупой";
        tri.Show();
        tri.Square();
        tri.ShowType();
        
        //прямоугольник
        Rectangle rec = new Rectangle();
        rec.Area();

        Console.ReadKey();
    }

}