using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            AriphmeticOperations AO = new AriphmeticOperations();
            double res = AO.PerformOperation("+", 2, 6);
            Console.WriteLine(res);

            
            //AO.DefineOperation("mod", (x, y) => x % y);
            //var mod = AO.PerformOperation("mod", 3.0, 2.0);
            //Assert.AreEqual(1.0, mod);


            Console.ReadKey();
        }
    } 
}
