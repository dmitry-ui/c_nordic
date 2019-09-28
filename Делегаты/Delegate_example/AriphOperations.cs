using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_example
{
    class Calculator
    {
        public Dictionary<string, Func<double, double, double>> Operation;

        public Calculator()
        {
            Operation = new Dictionary<string, Func<double, double, double>>();
            Operation.Add("+", (x, y) => x + y);
            Operation.Add("-", (x, y) => x - y);
            Operation.Add("*", (x, y) => x * y);
            Operation.Add("/", (x, y) => x / y);
        }

        public double PerformOperation(string type, double first, double second)
        {
            if (!Operation.ContainsKey(type))
                throw new Exception("Некорректная операция");
            return Operation[type](first, second);
        }
    }
}
