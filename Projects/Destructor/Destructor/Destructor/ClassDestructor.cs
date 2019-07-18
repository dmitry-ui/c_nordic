using System;
class MyDestructor
{
    public int x;  //некий член класса
    public MyDestructor(int i)
    {
        x = i;
    }
    ~ MyDestructor()
    {
        Console.WriteLine("Деструктор сработал.Удалим объект " +x);
    }

    public void MyGenerator(int i)
    {
        MyDestructor o = new MyDestructor(i);
    }
}