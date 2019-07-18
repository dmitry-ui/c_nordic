using System;
class ToPerem
{
    public int alfa;
    public int beta;
    public bool isSame(ToPerem a)
    {
        if (alfa == a.alfa && beta == a.beta) return true;
        else return false;
    }
    public void copyPerem(ToPerem a)
    {
        alfa = a.alfa;
        beta = a.beta;
    }
    public void Show()
    {
        Console.WriteLine("alfa= {0}; beta={1}",alfa, beta );
    }
}

class Start
{
   static void Main()
    {
        ToPerem val1 = new ToPerem();
        ToPerem val2 = new ToPerem();
        val1.alfa = 1;
        val1.beta = 2;
        val1.Show();
        val2.copyPerem(val1);
        val2.Show();
        if (val2.isSame(val1))
        { Console.WriteLine(" Одинаковые"); }
        else
        { Console.WriteLine(" Разные"); }

        val1.alfa = 2;
        val1.beta = 3;
        val1.Show();
        val2.Show();
        if (val2.isSame(val1))
        { Console.WriteLine(" Одинаковые"); }
        else
        { Console.WriteLine(" Разные"); }


    }

}