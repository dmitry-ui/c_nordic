using System;
class Factorial
{
    public int Fact(int i)
    {
        int res;
        if (i == 1)
        {
            //
            return 1;
        }
        else
        {
            res = i * Fact(i - 1);
            return res;
        }
    }
}
class ReverseString
{
  // Вывести символьную строку в обратном порядке.
    public void ReverseStr(string str)
    {
        if (str.Length > 0)
        {
            ReverseStr(str.Substring(1, str.Length - 1));
        }
        else
            return;
        Console.Write(str[0]);
    }
}

class Start
{
    static void Main()
    {
        //подсчитаем факториал
        int i = 7;
        Factorial a = new Factorial();
        Console.WriteLine("{0}!={1}", i, a.Fact(i));

        //строка наоборот
      
            string s = "В лесу поспела бузина";
            string s1 = "Шишил мышл, пернул - вышел";
            ReverseString rsOb = new ReverseString();
            Console.WriteLine("Исходная строка: " + s);
            Console.Write("Перевернутая строка: ");
            rsOb.ReverseStr(s);
            Console.WriteLine();

           
        

    }

}