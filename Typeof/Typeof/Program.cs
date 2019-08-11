using System;

namespace Typeof
{
    class Program
    {
        public enum myflags
        {
            first,
            second
        }
        static void Main(string[] args)
        {
            //получение типа класса с помощью typeof
            Type myType = typeof(myflags);
            Console.WriteLine(myType.ToString());

            //получение типа класса с помощью GetType()
            //предварительно необходимо создать объект класса
            myflags mf = myflags.first;
            Type myType1 = mf.GetType();
            Console.WriteLine(myType1.ToString());

            //третий способ получения типа класса 
            /*
             Первый параметр указывает на полное имя класса с пространством имен. 
             В данном случае класс User находится в пространстве имен TestConsole. 
             Второй параметр указывает, будет ли генерироваться исключение, если класс не удастся найти. 
             В данном случае значение false означает, что исключение не будет генерироваться. 
             И третий параметр указывает, надо ли учитывать регистр символов в первом параметре. 
             Значение true означает, что регистр не учитывается.
             */
            //Type myType2 = Type.GetType("myflags", false, true);
            //Console.WriteLine(myType2.ToString());


            Console.ReadKey();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
        public void Display()
        {
            Console.WriteLine("Имя: {0}  Возраст: {1}", this.Name, this.Age);
        }
        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}
