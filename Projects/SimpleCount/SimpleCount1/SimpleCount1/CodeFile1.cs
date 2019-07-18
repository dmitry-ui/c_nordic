using System;
class CheckNum
{
public bool isSimple(int value)
    {
        for(int i=2; i<value/i; i++)
        {
            if (value % i == 0)
            return false;
        }
        return true;
    }
}

class Start
{
    static void Main()
    {
        string inp;
        CheckNum Simple = new CheckNum();
        Console.WriteLine("Введите число:\n");
        inp = Console.ReadLine();
        int val = int.Parse(inp);
        if (Simple.isSimple(val))
            Console.WriteLine(val + " - простое число.");
        else
            Console.WriteLine(val + " - составное число.");


    }
}

