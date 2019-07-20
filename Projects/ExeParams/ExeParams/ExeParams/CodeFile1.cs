using System;
class ExeParams
{
    static void Main(string [] Arg)
    {
        //if(Arg.Length==2)
        //{
        //    Console.WriteLine(Arg[0] + Arg[1]);
        //    return;
        //}
        //Console.WriteLine("нЕобходимо ввести два параметра!");

        Console.WriteLine("В командной строке были следующие параметры:");
        for(int i=0; i<Arg.Length; i++)
        {
            Console.WriteLine(Arg[i]);
        }
        Console.ReadKey();
    }
}