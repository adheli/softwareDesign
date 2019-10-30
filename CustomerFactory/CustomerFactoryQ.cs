using System;

abstract class Customer
{
    protected string name;
    protected int age;
    protected double price;

    public Customer(String n, int a, double p)
    {
        name = n;
        age = a;
        price = p;
    }

    public void SetNewPrice(double newPrice)
    {
        price = newPrice;
    }

    public abstract double ReadPrice();
}

class RegularCustomer : Customer
{
    public RegularCustomer(String n, int a, double p) : base(n, a, p) { }

    public override double ReadPrice()
    {
        return price;
    }
}

class ChildCustomer : Customer
{
    public ChildCustomer(String n, int a, double p) : base(n, a, p) { }

    public override double ReadPrice()
    {
        return price * 0.5;
    }
}

class CustomerFactory
{
    public Customer GetCustomer(String name, int age, double price)
    {
        if (age < 17)
        {
            return new ChildCustomer(name, age, price);
        }
        else
        {
            return new RegularCustomer(name, age, price);
        }
    }
}

public class Ex1
{
    public static void Main()
    {
        double origPrice = 62.48;
        CustomerFactory cfactory = new CustomerFactory();
        Console.Write("Enter Name:");
        string name = Console.ReadLine();

        Console.Write("Enter Age:");
        string temp = Console.ReadLine();
        int age = Convert.ToInt32(temp);

        Customer c = cfactory.GetCustomer(name, age, origPrice);

        int choice = 1; double val = 0;

        while (choice != 3)
        {
            Console.WriteLine("1: Enter New Price");
            Console.WriteLine("2: Read Price");
            Console.WriteLine("3: Exit");
            Console.WriteLine("Enter Choice:");
            temp = Console.ReadLine();
            choice = Convert.ToInt32(temp);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Price");
                    temp = Console.ReadLine();
                    val = Convert.ToDouble(temp);
                    c.SetNewPrice(val);
                    break;
                case 2:
                    double res = (double)c.ReadPrice();
                    Console.WriteLine("Price: " + res);
                    break;
            }
        }
    }
}
