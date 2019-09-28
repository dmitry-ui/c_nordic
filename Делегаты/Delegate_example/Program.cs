using System;

namespace Delegate_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator ar = new Calculator();
            double res = ar.PerformOperation("+", 2.0, 2.1);
            Console.WriteLine(res);
            res = ar.PerformOperation("-", 3.0, 2.1);
            Console.WriteLine(res);
            res = ar.PerformOperation("*", 3.0, 2.1);
            Console.WriteLine(res);
            res = ar.PerformOperation("/", 3.0, 1.5);
            Console.WriteLine(res);
            ar.Operation.Add("%", (x, y) => x % y);
            res = ar.PerformOperation("%", 3.0, 1.6);
            Console.WriteLine(res);

            Console.ReadKey();
        }
    }
}
