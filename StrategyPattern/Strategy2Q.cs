using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace boolStrategy
{
    interface IBoolStrategy
    {
        bool DoOperation(int num1, int num2);
    }

    class BoolContext
    {
        private readonly IBoolStrategy strategy;

        public BoolContext(IBoolStrategy strategy)
        {
            this.strategy = strategy;
        }
        public bool ExecuteStrategy(int num1, int num2)
        {
            return strategy.DoOperation(num1, num2);
        }
    }

    public class OperationEqual : IBoolStrategy
    {
        public bool DoOperation(int num1, int num2)
        {
            return num1 == num2;
        }
    }

    public class OperationNotEqual : IBoolStrategy
    {
        public bool DoOperation(int num1, int num2)
        {
            return num1 != num2;
        }
    }

    public class OperationGreaterThan : IBoolStrategy
    {
        public bool DoOperation(int num1, int num2)
        {
            return num1 > num2;
        }
    }

    public class StrategyPatternDemo
    {
        public static void Main()
        {
            BoolContext context = new BoolContext(new OperationEqual());
            Console.WriteLine("10==9 = " + context.ExecuteStrategy(10, 9));

            context = new BoolContext(new OperationNotEqual());
            Console.WriteLine("10!=9 = " + context.ExecuteStrategy(10, 9));

            context = new BoolContext(new OperationGreaterThan());
            Console.WriteLine("10>9  = " + context.ExecuteStrategy(10, 9));
            Console.Read();
        }
    }
}
