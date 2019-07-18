using System;

class Shifrs
{
    static int Main(string [] Arg)
    {
        if (Arg.Length < 2)
        {
            Console.WriteLine("Необходимы два параметра");
            return 1;
        }
        if(Arg[0]!="Шифр" && Arg[0] != "Дешифр")
        {
            Console.WriteLine("Первый парамет должен быть Шифр/Дешифр");
            return 1;
        }
        for (int i = 1; i < Arg.Length; i++)
        {
            for (int j = 0; j < Arg[i].Length; j++)
            {
                if (Arg[0] == "Шифр")
                {
                    Console.Write((char)(Arg[i][j] + 1));
                }
                else
                {
                    Console.Write((char)(Arg[i][j] - 1));
                }

            }
            Console.Write(" ");
        }
        Console.WriteLine();
        return 0;
    }
}