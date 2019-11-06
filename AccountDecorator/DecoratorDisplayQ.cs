using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Display
{
    private String name;

    public Display(String n) { name = n; }

    public Display(Display dd) { name = dd.name; }

    virtual public void print() { Console.WriteLine("\t" + name); }

    virtual public void setName(String n) { name = n; }
}

class DisplayDecorator : Display
{
    protected Display display;
    protected String bLine = "*********************************";

    public DisplayDecorator(Display di) : base(di)
    {
        display = di;
    }
}

class UpperLineDecorator : DisplayDecorator
{
    public UpperLineDecorator(Display dd) : base(dd) { }

    public override void print()
    {
        Console.WriteLine(base.bLine);
        base.print();
    }
}

class LowerLineDecorator : DisplayDecorator
{
    public LowerLineDecorator(Display dd) : base(dd) { }

    public override void print()
    {
        base.print();
        Console.WriteLine(base.bLine);
    }
}

class FullLineDecorator : DisplayDecorator
{
    public FullLineDecorator(Display dd) : base(dd) { }

    public override void print()
    {
        Console.WriteLine(base.bLine);
        base.print();
        Console.WriteLine(base.bLine);
    }
}

class Program
{
    static void Main(string[] args)
    {
        int option = 0;

        Display d = new Display("Belem - Para");

        while (option != 6)
        {
            Console.WriteLine("\nChoose Option\n");
            Console.WriteLine("================\n");
            Console.WriteLine("1. Change Name");
            Console.WriteLine("2. Print Name");
            Console.WriteLine("3. Print Lower");
            Console.WriteLine("4. Print Upper");
            Console.WriteLine("5. Print Full Decorated");
            Console.WriteLine("6. Exit");

            option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                Console.Write("Enter new Name:");
                String newName = Console.ReadLine();
                d.setName(newName);

            }
            else if (option == 2)
            {
                d.print();
            }
            else if (option == 3)
            {
                Display newDisplay = new LowerLineDecorator(d);
                newDisplay.print();
            }
            else if (option == 4)
            {
                Display newDisplay = new UpperLineDecorator(d);
                newDisplay.print();
            }
            else if (option == 5)
            {
                Display newDisplay = new FullLineDecorator(d);
                newDisplay.print();
            }
            else if (option == 6)
            {
                Console.WriteLine("Exit");
            }
        }
    }
}

