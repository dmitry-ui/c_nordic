/*using System;
class Start
{
static void Main()
    {
        MyDestructor ob = new MyDestructor(1);
        for(int j=0; j<10; j++)
        ob.MyGenerator(j);
        Console.WriteLine("-----------------Конец программы----------ГОТОВО----");
    }
}
*/

// Продемонстрировать применение деструктора.
using System;
class Destruct
{
    public int x;
    public Destruct(int x)
    {
        this.x = x;  //this означает переменная x вызывающего объекта, т.е. переменная - член класса а не одноименный параметр конструктора
    }
    // Вызывается при утилизации объекта.
    ~Destruct()
    {
        Console.WriteLine("Уничтожить " + x);
    }
    // Создает объект и тут же уничтожает его.
    public void Generator(int i)
    {
        Destruct о = new Destruct(i);
    }
}
class DestructDemo
{
    static void Main()
    {
        int count;
        Destruct ob = new Destruct(0);
        /* А теперь создать большое число объектов.
        В какой-то момент произойдет "сборка мусора".
        Примечание: для того чтобы активизировать
        "сборку мусора", возможно, придется увеличить
        число создаваемых объектов. */
        for (count = 1; count < 100000; count++)
            ob.Generator(count);
        Console.WriteLine("Готово!");
        Console.WriteLine("Готово!");
        Console.WriteLine("Готово!");
        Console.WriteLine("Готово!");
        Console.WriteLine("Готово!");
        Console.WriteLine("Готово!");

    }
}