using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    static class Functions
    {
        public static void Decrement(this Counter c)
        {
            c.Count--;
        }
    }

    class Counter
    {
        public int Count { get; set; }
        // automatic property for var "int count"
        public void Increment() { Count++; }
        public int ReadValue() { return Count; }
    }

    // insert extension method for "void decrement()

    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            Counter c = new Counter { Count = 1 };
            	//Define Counter object c using object initializer to set count=0

            while (option != 4)
            {
                Console.WriteLine("\nChoose Option\n");
                Console.WriteLine("================\n");
                Console.WriteLine("1. Increment");
                Console.WriteLine("2. Decrement");
                Console.WriteLine("3. Read Value");
                Console.WriteLine("4. Exit");

                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    c.Increment();

                }
                else if (option == 2)
                {
                    c.Decrement();
                }
                else if (option == 3)
                {
                    int res = c.ReadValue();
                    Console.WriteLine("Val="+res);
                }

                else if (option == 4)
                {
                    Console.WriteLine("Exit");
                }
            }
        }
    }
}
