using System;

namespace ColorTriAngle
{
    /*
     Благодаря наследованию в классе ColorTriangle могут использоваться определенные ранее классы Triangle и TwoDShape, к элементам которых добавляется лишь
та информация, которая требуется для конкретного применения данного класса.
В этом отчасти и состоит ценность наследования, поскольку оно допускает повторное
использование кода.
Приведенный выше пример демонстрирует еще одно важное положение: ключевое слово base всегда обозначает ссылку на конструктор ближайшего по иерархии
базового класса. Так, ключевое слово base в классе ColorTriangle обозначает вызов
конструктора из класса Triangle, а ключевое слово base в классе Triangle — вызов
конструктора из класса TwoDShape. Если же в иерархии классов конструктору базового класса требуются параметры, то все производные классы должны предоставлять
эти параметры вверх по иерархии, независимо от того, требуются они самому производному классу или нет.
     */
    class TwoDim
    {
        private double h_Width;
        private double h_Height;
        public double width
        {
            get { return h_Width; }
            set { h_Width = value < 0 ? -value : value; }
        }
        public double Height
        {
            get { return h_Height; }
            set { h_Height = value < 0 ? -value : value;
 }
        }
        public TwoDim() { width = Height = 0; }
        public TwoDim(double param1, double param2)
        {
            width = param1;
            Height = param2;

        }
        public void Show()
        {
            Console.WriteLine("Свойства объекта:");
            Console.WriteLine("Длина: {0}", width);
            Console.WriteLine("Высота: {0}", Height);
        }
    }
    class TriAngle : TwoDim
    {
        private string Style;
        public TriAngle(string parametr_1, double parametr_2, double parametr_3) : base(parametr_2, parametr_3)
        {
            Style = parametr_1;
        }
        new public void Show()
        {
            base.Show();
            Console.WriteLine("Тип: {0}", Style);
        }

    }
    class ColorTriAngle: TriAngle
    {
        private string color;
        public ColorTriAngle(string color, string type, double width, double height):base(type, width, height)
        {
            this.color = color;
        }
        new public void Show()
        {
            base.Show();
            Console.WriteLine("Цвет: {0}", color);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TwoDim td = new TwoDim();
                td.Show();
            TriAngle ta = new TriAngle("Тупой", 12.1, 45.8);
            ta.Show();
            ColorTriAngle ct = new ColorTriAngle("красный", "острый", 5, 7.6);
            ct.Show();
            Console.ReadKey();
        }
    }
}
