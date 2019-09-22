using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class AriphmeticOperations
    {

        private delegate double OperationDelegate(double x, double y);
        private Dictionary<string, OperationDelegate> _operations;

        public AriphmeticOperations()
        {
            _operations =
                new Dictionary<string, OperationDelegate>
                {
            { "+", delegate(double x, double y) { return x+y; } }, //можно используя анонимные функции
            { "-", (x, y) => x - y },         //используя лямбда выражение
            { "*", this.DoMultiplication },
            { "/", this.DoDivision },
                };
        }

        public double PerformOperation(string op, double x, double y)
        {
            if (!_operations.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            return _operations[op](x, y);
        }

        //public void DefineOperation(string op, Func<double, double, double> body)
        //{
        //    if (_operations.ContainsKey(op))
        //        throw new ArgumentException(string.Format("Operation {0} already exists", op), "op");
        //    _operations.Add(op, body);
        //}

        //public double PerformOperation(string op, double x, double y)
        //{
        //    switch (op)
        //    {
        //        case "+": return DoAddition(x, y);
        //        case "-": return DoSubtraction(x, y);
        //        case "*": return DoMultiplication(x, y);
        //        case "/": return DoDivision(x, y);
        //        default: throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
        //    }
        //}

        private double DoDivision(double x, double y) { return x / y; }
        private double DoMultiplication(double x, double y) { return x * y; }
        //private double DoSubtraction(double x, double y) { return x - y; }
        //private double DoAddition(double x, double y) { return x + y; }

    } 
}
