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

    //конструкторы
    public TwoDimFigure(int parametr_a, int parametr_b)
    {
        a = parametr_a;
        b = parametr_b;
    }
    public TwoDimFigure()
    {
        a = 0;
        b = 0;
    }

    public void Show()
    {
        Console.WriteLine("Длина фигуры: {0}, ширина фигуры: {1}.",PropA,PropB);
    }
}
class Triangle: TwoDimFigure
{
    /*
    Когда в производном классе указывается ключевое слово base, вызывается конструктор
    из его непосредственного базового класса. Следовательно, ключевое слово base всегда
    обращается к базовому классу, стоящему в иерархии непосредственно над вызывающим классом. 
    Это справедливо даже для многоуровневой иерархии классов. Аргументы передаются базовому конструктору 
    в качестве аргументов метода base(). 
    Если же ключевое слово отсутствует, то автоматически вызывается конструктор, используемый
    в базовом классе по умолчанию. 
    */

    //Когда конструкторы определяются как в базовом, так и в производном классе, 
    //процесс построения объекта несколько усложняется, поскольку должны выполняться
    //конструкторы обоих классов.В данном случае приходится обращаться к еще одному
    //ключевому слову языка С#: base, которое находит двоякое применение: во-первых, для
    //вызова конструктора базового класса; и во-вторых, для доступа к члену базового класса,
    //скрывающегося за членом производного класса. Ниже будет рассмотрено первое применение ключевого слова base.

    //Если конструктор определен только в производном классе, то все происходит очень просто:
    //конструируется объект производного класса, а базовая часть объекта автоматически конструируется его конструктором, 
    //используемым по умолчанию.
    public string typeOffTriangle;
    //Конструкторы.
    //так автоматически будет вызван конструктор базового класса 
    //без параметров определенный пользователем

    //public Triangle()
    //{
    //    typeOffTriangle = "Равнобедренный";
    //}
    //или так:
    public Triangle() : base()
    {
        typeOffTriangle = "Равнобедренный";
    }

    //а так один параметр используется в конструкторе производного класса
    //а в конструктор базового класса передаются два параметра
    public Triangle(string typeOffTriangle, int parametr_a, int parametr_b) : base(parametr_a, parametr_b)
    {
        this.typeOffTriangle=typeOffTriangle;
    }

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
        //TwoDimFigure fig = new TwoDimFigure();
        //fig.Show();
        
        ////треугольник
        //Triangle tri = new Triangle();
        //tri.typeOffTriangle = "Тупой";
        //tri.Show();
        //tri.Square();
        //tri.ShowType();
        
        ////прямоугольник
        //Rectangle rec = new Rectangle();
        //rec.Area();


        Triangle tri2 = new Triangle();
        Console.WriteLine(tri2.GetA());
        Console.WriteLine(tri2.GetB());
        Console.WriteLine(tri2.typeOffTriangle);

        Triangle tri3 = new Triangle("Острый", 47, 259);
        Console.WriteLine(tri3.GetA());
        Console.WriteLine(tri3.GetB());
        Console.WriteLine(tri3.typeOffTriangle);





        Console.ReadKey();
    }

}