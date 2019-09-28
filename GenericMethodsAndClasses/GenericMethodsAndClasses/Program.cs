using System;

namespace GenericMethodsAndClasses
{
    class Program
    {

        /*Реализовать класс Account
        ● Два свойства:
        ○ int Id { get, private set },
        ○ string Name { get, private set },
        ● Конструктор с параметрами для их заполнения
        ● Публичный метод void WriteProperties(), выводящий параметры в
        консоль.
        Затем сделать класс обобщённым, обобщяя его по типу свойства Id.
        В основном потоке программы создать несколько экземпляров класса
        Account с различными типами данных для Id: int, string, Guid.Для всех
        вызвать метод WriteProperties.        */

        static void Main(string[] args)
        {
            Account<int> ac = new Account<int>(15, "Саша");
            Account<string> ac2 = new Account<string>("15", "Саша");
            ac.WriteProperties();
            ac2.WriteProperties();
            Console.ReadKey();
        }
    }

    class Account<T>
    {
        T Id { get; }
        string Name { get; }

        public Account(T id,string std)
        {
            Id = id;
            Name = std;
        }

        public void WriteProperties()
        {
            Console.WriteLine($"{Id}    {Name}");
        }


    }
}
